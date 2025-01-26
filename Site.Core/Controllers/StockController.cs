using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Data;
using Site.Data.Models;

namespace Site.Core.Controllers;

public class StockController : Controller
{
    private readonly ApplicationContext _context;
    private static readonly Random _random = new Random();

    public StockController(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Stock.Include(s => s.Product).OrderBy(x => x.Product.Name).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var stock = await _context.Stock
            .Include(s => s.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (stock == null)
        {
            return NotFound();
        }

        stock.SupplierProducts = await _context.SupplierProducts
            .Include(s => s.Supplier)
            .Where(x => x.ProductId == stock.ProductId).ToListAsync();

        return View(stock);
    }

    [HttpPost, ActionName("Restock")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Restock(int id)
    {
        var stock = await _context.Stock
            .FirstOrDefaultAsync(m => m.Id == id);

        var supplier = await _context.SupplierProducts
            .Where(s => s.ProductId == stock.ProductId)
            .OrderBy(x => x.SupplierPrice)
            .Select(x => x.Supplier)
            .FirstOrDefaultAsync();

        if (stock == null || supplier == null)
        {
            return NotFound();
        }

        var order = new Order
        {
            Id = await GenerateUniqueOrderIdAsync(),
            SupplierId = supplier.Id,
            ProductId = stock.ProductId,
            Code = Guid.NewGuid(),
            Quantity = (stock.MinimumStock * 2) - stock.AvailableStock
        };

        stock.AvailableStock += order.Quantity;

        try
        {
            _context.Orders.Add(order);
            _context.Stock.Update(stock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = stock.Id });
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Order), order);
        }
    }

    private async Task<int> GenerateUniqueOrderIdAsync()
    {
        int fourDigitId;
        bool isUnique = false;

        do
        {
            fourDigitId = _random.Next(1000, 9999);
            isUnique = !await _context.Orders.AnyAsync(s => s.Id == fourDigitId);
        }
        while (!isUnique);

        return fourDigitId;
    }
}

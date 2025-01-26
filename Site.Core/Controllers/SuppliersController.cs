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

public class SuppliersController : Controller
{
    private readonly ApplicationContext _context;
    private static readonly Random _random = new Random();

    public SuppliersController(ApplicationContext context) 
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Suppliers.OrderBy(x => x.Company).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = await _context.Suppliers
            .Include(s => s.SupplierProducts)
            .ThenInclude(e => e.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Supplier supplier)
    {
        try
        {
            if (ModelState.IsValid)
            {
                supplier.Id = await GenerateUniqueSupplierIdAsync();
                _context.Add(supplier);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return View(supplier);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = await _context.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (supplier == null)
        {
            return NotFound();
        }

        return View(supplier);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Supplier supplier)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Update(supplier);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = supplier.Id });
            }
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return RedirectToAction(nameof(Details), new { id = supplier.Id });
    }

    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var supplier = await _context.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (supplier == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
        }

        return View(supplier);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);
        if (supplier == null)
        {
            return RedirectToAction(nameof(Details), new { id = supplier.Id });
        }

        try
        {
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
        }
    }

    public async Task<IActionResult> Order(int productId, int supplierId)
    {
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == productId);

        var supplier = await _context.Suppliers
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == supplierId);

        if (product == null || supplier == null)
        {
            return NotFound();
        }

        var order = new Order
        {
            Id = await GenerateUniqueOrderIdAsync(),
            SupplierId = supplierId,
            Supplier = supplier,
            ProductId = productId,
            Product = product
        };

        return View(order);
    }

    [HttpPost, ActionName("Order")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OrderConfirmed(Order order)
    {
        order.Code = Guid.NewGuid();

        var supplier = await _context.Suppliers.FindAsync(order.SupplierId);
        var supplierProduct = await _context.SupplierProducts.FindAsync(order.SupplierId, order.ProductId);
        var stock = await _context.Stock.Where(s => s.ProductId == order.ProductId).FirstOrDefaultAsync();

        if (supplier == null || supplierProduct == null || stock == null)
        {
            return RedirectToAction(nameof(Index));
        }

        stock.AvailableStock += order.Quantity;

        order.Product = supplierProduct.Product;
        order.ProductId = supplierProduct.ProductId;
        order.Supplier = supplierProduct.Supplier;

        try
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Stock", new { id = stock.Id });
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Order), order);
        }
    }

    private async Task<int> GenerateUniqueSupplierIdAsync()
    {
        int fourDigitId;
        bool isUnique = false;

        do
        {
            fourDigitId = _random.Next(1000, 9999);
            isUnique = !await _context.Suppliers.AnyAsync(s => s.Id == fourDigitId);
        }
        while (!isUnique);

        return fourDigitId;
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

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

public class StoresController : Controller
{
    private readonly ApplicationContext _context;
    private static readonly Random _random = new Random();

    public StoresController(ApplicationContext context) 
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Stores.OrderBy(x => x.Name).ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores
            .Include(s => s.StoreProducts)
            .ThenInclude(e => e.Product)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Store store)
    {
        try
        {
            if (ModelState.IsValid)
            {
                store.Id = await GenerateUniqueStoreIdAsync();
                _context.Add(store);
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
        return View(store);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Store store)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Update(store);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Details), new { id = store.Id });
            }
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.
            ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists " +
                "see your system administrator.");
        }
        return RedirectToAction(nameof(Details), new { storeId = store.Id });
    }

    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var store = await _context.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (store == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
        }

        return View(store);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var store = await _context.Stores.FindAsync(id);
        if (store == null)
        {
            return RedirectToAction(nameof(Details), new { id = store.Id });
        }

        try
        {
            _context.Stores.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
        }
    }

    public async Task<IActionResult> Sell(int storeId, int productId)
    {
        var store = await _context.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == storeId);

        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == productId);

        if (product == null || store == null)
        {
            return NotFound();
        }

        var storeSale = new StoreSale
        {
            Id = await GenerateUniqueSupplyIdAsync(),
            StoreId = storeId,
            Store = store,
            ProductId = productId,
            Product = product
        };

        return View(storeSale);
    }

    [HttpPost, ActionName("Sell")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SellConfirmed(int salesCount, StoreSale storeSale)
    {
        storeSale.Date = DateTime.Now;
        storeSale.Code = Guid.NewGuid();

        var store = await _context.Stores.FindAsync(storeSale.StoreId);
        var storeProduct = await _context.StoreProducts.FindAsync(storeSale.StoreId, storeSale.ProductId);
        if (store == null || storeProduct == null)
        {
            return RedirectToAction(nameof(Index));
        }

        storeProduct.AvailableStock -= storeSale.Quantity;

        try
        {
            _context.StoreProducts.Update(storeProduct);
            _context.StoreSales.Add(storeSale);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = store.Id });
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Sell), storeSale);
        }
    }

    public async Task<IActionResult> Supply(int storeId, int productId)
    {
        var store = await _context.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == storeId);

        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == productId);

        if (product == null || store == null)
        {
            return NotFound();
        }

        var supply = new Supply
        {
            Id = await GenerateUniqueSupplyIdAsync(),
            StoreId = storeId,
            Store = store,
            ProductId = productId,
            Product = product
        };

        return View(supply);
    }

    [HttpPost, ActionName("Supply")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SupplyConfirmed(Supply supply)
    {
        supply.Date = DateTime.Now;
        supply.Code = Guid.NewGuid();

        var store = await _context.Stores.FindAsync(supply.StoreId);
        var storeProduct = await _context.StoreProducts.FindAsync(supply.StoreId, supply.ProductId);
        var stock = await _context.Stock.Where(s => s.ProductId == supply.ProductId).FirstOrDefaultAsync();

        if (store == null || storeProduct == null || stock == null)
        {
            return RedirectToAction(nameof(Index));
        }

        if (supply.Quantity > stock.AvailableStock)
        {
            TempData["ErrorMessage"] = "Insufficient stock. Currently available stock: " + stock.AvailableStock;
            return RedirectToAction(nameof(Supply), supply);
        }

        stock.AvailableStock -= supply.Quantity;
        storeProduct.AvailableStock += supply.Quantity;

        try
        {
            _context.StoreProducts.Update(storeProduct);
            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = store.Id });
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Supply), supply);
        }
    }

    private async Task<int> GenerateUniqueStoreIdAsync()
    {
        int fourDigitId;
        bool isUnique = false;

        do
        {
            fourDigitId = _random.Next(1000, 9999);
            isUnique = !await _context.Stores.AnyAsync(s => s.Id == fourDigitId);
        }
        while (!isUnique);

        return fourDigitId;
    }

    private async Task<int> GenerateUniqueSupplyIdAsync()
    {
        int fourDigitId;
        bool isUnique = false;

        do
        {
            fourDigitId = _random.Next(1000, 9999);
            isUnique = !await _context.Supplies.AnyAsync(s => s.Id == fourDigitId);
        }
        while (!isUnique);

        return fourDigitId;
    }

    private int GenerateRandomSalesCount(int currentStock)
    {
        return _random.Next(0, currentStock);
    }
}

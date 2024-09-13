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
        return View(await _context.Stores.ToListAsync());
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

    // GET: Students/Create
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
                store.Id = await GenerateUniqueFourDigitIdAsync();
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

    public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
    {
        if (id == null)
        {
            return NotFound();
        }

        var student = await _context.Stores
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);

        if (student == null)
        {
            return NotFound();
        }

        if (saveChangesError.GetValueOrDefault())
        {
            ViewData["ErrorMessage"] =
                "Delete failed. Try again, and if the problem persists " +
                "see your system administrator.";
        }

        return View(student);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _context.Stores.FindAsync(id);
        if (student == null)
        {
            return RedirectToAction(nameof(Index));
        }

        try
        {
            _context.Stores.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateException /* ex */)
        {
            //Log the error (uncomment ex variable name and write a log.)
            return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
        }
    }

    private async Task<int> GenerateUniqueFourDigitIdAsync()
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
}

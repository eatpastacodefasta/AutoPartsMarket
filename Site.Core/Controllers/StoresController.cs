using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Site.Data;

namespace Site.Core.Controllers;

public class StoresController : Controller
{
    private readonly ApplicationContext _context;

    public StoresController(ApplicationContext context) 
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Stores.ToListAsync());
    }
}

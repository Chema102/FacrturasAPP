using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacrturasAPP.Models;
using System.Runtime.Intrinsics.Arm;

namespace FacrturasAPP.Controllers
{
    public class FacturasController : Controller
    {
        //private readonly FctContext _context;

        //public FacturasController(FctContext context)
        //{
        //    _context = context;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Facturas.AsNoTracking().Where(m => m.Dltt == false).ToListAsync());
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    var factura = await GetById(id);

        //    if (factura == null)
        //        return NotFound();

        //    return View(factura);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Fecha,Total")] Factura factura)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        factura.Crt = DateTime.Now;
        //        factura.Uppdt = DateTime.Now;
        //        factura.Dltt = false;

        //        _context.Add(factura);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(factura);
        //}

        //public async Task<IActionResult> Edit(int id)
        //{
        //    var factura = await GetById(id);

        //    if (factura == null)
        //        return NotFound();

        //    return View(factura);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Total,Crt,Uppdt,Dltt")] Factura factura)
        //{
        //    if (id != factura.Id)
        //        return NotFound();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(factura);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FacturaExists(factura.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(factura);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var factura = await GetById(id);

        //    if (factura == null)
        //        return NotFound();

        //    return View(factura);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var factura = await GetById(id);

        //    if (factura != null)
        //    {
        //        factura.Dltt = true;
        //        factura.Uppdt= DateTime.Now;
        //        _context.Facturas.Update(factura);
        //    }

        //    await _context.SaveChangesAsync();

        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FacturaExists(int id)
        //{
        //    return _context.Facturas.Any(e => e.Id == id && e.Dltt == false);
        //}

        //public async Task<Factura?> GetById(int id)
        //{
        //    var factura = await _context.Facturas
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(f => f.Id == id && f.Dltt == false);
            
        //    return factura;
        //}
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacrturasAPP.Models;

namespace FacrturasAPP.Controllers
{
    public class FacturaDetallesController : Controller
    {
        //private readonly FctContext _context;

        //public FacturaDetallesController(FctContext context)
        //{
        //    _context = context;
    
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var fctContext =await _context.FacturaDetalles
        //        .Include(f => f.Factura)
        //        .Include(f => f.Producto)
        //        .ToListAsync();

        //    return View(fctContext);
        //}

        //public async Task<IActionResult> Details(int id)
        //{
        //    var facturaDetalle = await GetById(id);

        //    if (facturaDetalle == null)
        //        return NotFound();

        //    return View(facturaDetalle);
        //}

        //public IActionResult Create()
        //{
        //    ListJoins();

        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,FacturaId,ProductoId,Precio")] FacturaDetalle facturaDetalle)
        //{

        //    facturaDetalle.Crt = DateTime.Now;
        //    facturaDetalle.Uppdt = DateTime.Now;
        //    facturaDetalle.Dltt = false;

        //    if (ModelState.IsValid)
        //    {
        //        _context.FacturaDetalles.Add(facturaDetalle);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    ListJoins();
        //    return View(facturaDetalle);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var facturaDetalle = await _context.FacturaDetalles.FindAsync(id);
        //    if (facturaDetalle == null)
        //    {
        //        return NotFound();
        //    }

        //    ListJoins();
        //    return View(facturaDetalle);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FacturaId,ProductoId,Precio,Crt,Uppdt,Dltt")] FacturaDetalle facturaDetalle)
        //{
        //    if (id != facturaDetalle.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(facturaDetalle);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FacturaDetalleExists(facturaDetalle.Id))
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
        //    ListJoins();
        //    return View(facturaDetalle);
        //}

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var facturaDetalle = await GetById(id);

        //    if (facturaDetalle == null)
        //        return NotFound();

        //    return View(facturaDetalle);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var facturaDetalle = await GetById(id);

        //    if (facturaDetalle != null)
        //        _context.FacturaDetalles.Remove(facturaDetalle);

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool FacturaDetalleExists(int id)
        //{
        //    return _context.FacturaDetalles.Any(e => e.Id == id && e.Dltt == false);
        //}

        //private async Task<FacturaDetalle?> GetById(int id)
        //{
        //    var facturaDetalle = await _context.FacturaDetalles
        //        .Include(f => f.Factura)
        //        .Include(f => f.Producto)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(f => f.Id == id && f.Dltt == false);

        //    return facturaDetalle;
        //}

        //private void ListJoins()
        //{
        //    ViewData["FacturaId"] = new SelectList(_context.Facturas.Where(m => m.Dltt == false)
        //        .Select(m => new { Id = m.Id, Factura = m.Total.ToString() + "$ - " + m.Fecha }), "Id", "Factura");
        //    ViewData["ProductoId"] = new SelectList(_context.Productos.Where(m => m.Dltt == false), "Id", "Id");
            
        //}
    }
}

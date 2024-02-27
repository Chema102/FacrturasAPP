using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacrturasAPP.Models;

namespace FacrturasAPP.Controllers
{
    public class ProductosController : Controller
    {
        private readonly FctContext _context;

        public ProductosController(FctContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.AsNoTracking().Where(m => m.Dltt == false).ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id && m.Dltt == false);

            if (producto == null)
                return NotFound();

            return View(producto);
        }



        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripccion,Crt,Uppdt,Dltt")] Producto producto)
        {
            if (ModelState.IsValid)
            {

                producto.Crt = DateTime.Now;
                producto.Uppdt = DateTime.Now;
                producto.Dltt = false;

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Descripccion,Crt,Uppdt,Dltt")] Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    producto.Uppdt = DateTime.Now;

                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ProductoExists(producto.Id))
                    {
                        return NotFound(ex);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id && m.Dltt == false);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var producto = await GetById(id);

            if (producto != null)
            {
                producto.Dltt = true;

                _context.Productos.Update(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
            return _context.Productos.Any(e => e.Id == id && e.Dltt == false);
        }

        public async Task<Producto?> GetById(string id)
        {

            var producto = await _context.Productos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (producto == null)
                return null;

            return producto;
        }
    }
}

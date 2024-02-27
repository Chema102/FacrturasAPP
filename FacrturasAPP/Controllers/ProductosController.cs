using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            return View(await _context.Productos.AsNoTracking().Where(m => m.Dltt == false).ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

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

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

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
                    return NotFound(ex);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var producto = await GetById(id);

            if (producto != null)
            {
                producto.Dltt = true;
                producto.Uppdt = DateTime.Now;
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
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            return producto;
        }
    }
}

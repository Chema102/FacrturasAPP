using Microsoft.AspNetCore.Mvc;
using FacturasAPP.DTO.Models.Services;
using FacturasAPP.DTO.Dto;

namespace FacrturasAPP.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductosServices _productosServices;
        public ProductosController(IProductosServices productosServices)
        {
            _productosServices = productosServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productosServices.Get());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await _productosServices.GetById(id);

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
        public async Task<IActionResult> Create([Bind("Id,Description")] ProducDto producto)
        {
            if (ModelState.IsValid)
            {
                var isResult = await _productosServices.Add(producto);

                if (isResult) 
                    return RedirectToAction(nameof(Index));
            }

            return View(producto);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await _productosServices.GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Description,CreatedDate")] ProducDto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var isUpdate = await _productosServices.Update(producto);

                if(isUpdate)
                    return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
                return NotFound();

            var producto = await _productosServices.GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var isDelete = await _productosServices.Delete(id);
            
            if(!isDelete)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

    }
}

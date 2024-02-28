using Microsoft.AspNetCore.Mvc;
using FacturasAPP.DTO.Models.Services;
using FacturasAPP.DTO.Dto;

namespace FacrturasAPP.Controllers
{
    public class FacturasController : Controller
    {
        private readonly IFacturaServices _facturaServices;

        public FacturasController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _facturaServices.Get());
        }

        public async Task<IActionResult> Details(int id)
        {
            var factura = await _facturaServices.GetById(id);

            if (factura == null)
                return NotFound();

            return View(factura);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Total")] FacturaDto factura)
        {
            if (ModelState.IsValid)
            {
                var isAdd = await _facturaServices.Add(factura);

                if (true)
                    return RedirectToAction(nameof(Index));
            }
            return View(factura);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var factura = await _facturaServices.GetById(id);

            if (factura == null)
                return NotFound();

            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Total")] FacturaDto factura)
        {
            if (id != factura.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var isUpdate = await _facturaServices.Update(factura);

                if (isUpdate)
                    return RedirectToAction(nameof(Index));
            }
        
            return View(factura);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var factura = await _facturaServices.GetById(id);

            if (factura == null)
                return NotFound();

            return View(factura);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDelete = await _facturaServices.Delete(id);
            
            if (!isDelete)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

    }
}

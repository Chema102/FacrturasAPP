using FacturasAPP.DTO.Dto;
using FacturasAPP.DTO.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FacrturasAPP.Controllers
{
    public class FacturaDetallesController : Controller
    {
        private readonly IFacturaDetalleServices _facturaDetalleServices;
        public FacturaDetallesController(IFacturaDetalleServices facturaDetalleServices)
        {
            _facturaDetalleServices = facturaDetalleServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _facturaDetalleServices.Get());
        }

        public async Task<IActionResult> Details(int id)
        {
            var facturaDetalle = await _facturaDetalleServices.GetById(id);

            if (facturaDetalle == null)
                return NotFound();

            return View(facturaDetalle);
        }

        public IActionResult Create()
        {
            ListJoins();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FacturaId,ProductoId,Precio")] FacturaDetalleDto facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                var isAdd = await _facturaDetalleServices.Add(facturaDetalle);

                if(isAdd)
                    return RedirectToAction(nameof(Index));
            }
            ListJoins();
            return View(facturaDetalle);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _facturaDetalleServices.GetById(id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            ListJoins();
            return View(facturaDetalle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FacturaId,ProductoId,Precio,Crt")] FacturaDetalleDto facturaDetalle)
        {
            if (id != facturaDetalle.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                var isUpdate =await _facturaDetalleServices.Update(facturaDetalle);

                if (isUpdate)
                    return RedirectToAction(nameof(Index));
            }

            ListJoins();
            return View(facturaDetalle);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var facturaDetalle = await _facturaDetalleServices.GetById(id);

            if (facturaDetalle == null)
                return NotFound();

            return View(facturaDetalle);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isDelete = await _facturaDetalleServices.Delete(id);

            if (!isDelete)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }

        private async void ListJoins()
        {
            var selectListItems = await _facturaDetalleServices.GetDataSelect();

            ViewData["FacturaId"] = new SelectList( selectListItems.Factura, "Id", "Select");
            ViewData["ProductoId"] = new SelectList( selectListItems.Producto, "Id", "Id");

        }
    }
}

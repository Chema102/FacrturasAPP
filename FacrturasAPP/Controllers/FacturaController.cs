using FacrturasAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacrturasAPP.Controllers
{
    public class FacturaController : Controller
    {
        private readonly FctContext _FcrtContext;
        public FacturaController(FctContext context )
        {
            _FcrtContext = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _FcrtContext.Facturas.ToListAsync());
        }
    }
}

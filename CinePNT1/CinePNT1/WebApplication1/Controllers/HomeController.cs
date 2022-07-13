using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
using WebApplication1.Models;
using WebCineMVC;
//using WebCineMVC.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly CineContext _context;

        public HomeController(CineContext context)
        {
            _context = context;
        }

        
        public IActionResult Index()
        {
            //Aca usaremos el metodo para listar las peliculas
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(int? peli)
        {
            //Redireccionamos el id de pelicula elegida al controller de compras
            if (peli != null)
            {
                return RedirectToAction("Create", "Compras", new { numeroPeli = peli });
            }
            else {
                ViewData["ErrorSeleccion"] = "Debe seleccionar una película";
                ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Nombre");
                return View();
            }
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
    }
}

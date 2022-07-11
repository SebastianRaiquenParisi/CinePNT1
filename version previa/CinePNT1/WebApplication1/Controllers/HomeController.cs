using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebCineMVC;
using WebCineMVC.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly CineContext _context;

        public HomeController(CineContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //Aca usaremos el metodo para listar las peliculas
            ViewData["PeliculaId"] = CrearSelectListPeliculas(_context.Peliculas);
            
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index(int peli)
        {

            //var idDePeli = await _context.Funciones.Where(f => f.PeliculaId == peliId).FirstOrDefault(); 
            TempData["PeliculaHome"] = peli;
            return RedirectToAction("Create","Compras", new { id = peli }, FormMethod);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IEnumerable<SelectListItem> CrearSelectListPeliculas(IEnumerable<Pelicula> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Pelicula pelicula in list)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = pelicula.Nombre,
                    Value = pelicula.Id.ToString(),
                    Selected = false
                };
                selectList.Add(selectItem);
            }


            return selectList;
        }


    }
}

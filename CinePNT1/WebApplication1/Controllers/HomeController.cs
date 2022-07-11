﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index(int peli)
        {
            //Redireccionamos el id de pelicula elegida al controller de compras
            return RedirectToAction("Create","Compras", new {numeroPeli = peli});
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

    }
}

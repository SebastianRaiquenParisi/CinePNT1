using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCineMVC;
using WebCineMVC.Models;

namespace WebCineMVC.Controllers
{
    public class ComprasController : Controller
    {
        private readonly CineContext _context;
       

        public ComprasController(CineContext context)
        {
            _context = context;
         }

        // GET: Compras
        public  IActionResult CompraFinalizada()
        {
            var compra = _context.Compras.OrderByDescending(c => c.Id).FirstOrDefault();
            var funcion = _context.Funciones.Find(compra.FuncionId);
            var pelicula = _context.Peliculas.Find(funcion.PeliculaId);
            ViewData["Fecha"] = funcion.Fecha.ToString();
            ViewData["PElegida"] = pelicula.Nombre;
            return View(compra);
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var compra = await _context.Compras
                .Include(c => c.Funcion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create(int? numeroPeli)
        {
            ViewData["FuncionId"] = CrearSelectListFunciones(_context.Funciones, numeroPeli.ToString());
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,FuncionId,CantidadDeEntradas")] Compra compra)
        {
            var funciones = _context.Funciones;
            var funcion = funciones.Find(compra.FuncionId);

            if (ModelState.IsValid)
            {
                if (validarEntradasDisponibles(funcion.TicketsDisponibles, compra.CantidadDeEntradas))
                {
                    funcion.actualizarTickets(compra.CantidadDeEntradas);
                    _context.Add(compra);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CompraFinalizada));
                }
                else {
                    ViewData["ErrorTicketsInsuficientes"] = "No hay suficientes entradas para procesar tu pedido";
                    ViewData["FuncionId"] = CrearSelectListFunciones(_context.Funciones, funcion.PeliculaId.ToString());
                    return View();
                }

            }

            ViewData["FuncionId"] = CrearSelectListFunciones(_context.Funciones, funcion.PeliculaId.ToString());
            return View(compra);
        }

        private bool validarEntradasDisponibles(int ticketsDisponibles, int cantidadEntradas) {
            return cantidadEntradas <= ticketsDisponibles;
        }

        //Con este metodo, logramos listar las fechas de las funciones correspondientes a la pelicula seleccionada
        public IEnumerable<SelectListItem> CrearSelectListFunciones(IEnumerable<Funcion> funciones, string peli)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            
            foreach (Funcion funcion in funciones)
            {

                if (funcion.PeliculaId.ToString().Equals(peli))
                {
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Text = funcion.Fecha.ToString(),
                            Value = funcion.Id.ToString(),
                            Selected = false
                        };
                        selectList.Add(selectItem);
                    }
                }
            }


            return selectList;
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}

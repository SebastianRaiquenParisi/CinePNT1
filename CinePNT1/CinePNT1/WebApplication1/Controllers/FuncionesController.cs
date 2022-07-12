using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCineMVC;
using WebCineMVC.Models;

namespace WebCineMVC.Controllers
{
    public class FuncionesController : Controller
    {
        private readonly CineContext _context;

        public FuncionesController(CineContext context)
        {
            _context = context;
        }

        // GET: Funciones
        public async Task<IActionResult> Index()
        {
            var cineContext = _context.Funciones.Include(f => f.Pelicula).Include(f => f.Sala);
            return View(await cineContext.ToListAsync());
        }

        // GET: Funciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // GET: Funciones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Nombre");
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Numero");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,SalaId,PeliculaId")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                var salas = _context.Salas;
                var sala = salas.Find(funcion.SalaId);
                funcion.TicketsDisponibles = sala.Asientos;
                _context.Add(funcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["nombrePeli"] = new SelectList(_context.Peliculas, "Id", "Nombre");
            ViewData["numeroSala"] = new SelectList(_context.Salas, "Id", "Numero");
            return View(funcion);
        }

        // GET: Funciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["PelId"] = new SelectList(_context.Peliculas,"Id","Nombre", funcion.PeliculaId);
            ViewData["SId"] = new SelectList(_context.Salas, "Id", "Numero", funcion.SalaId);
            return View(funcion);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,SalaId,PeliculaId")] Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionExists(funcion.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PelId"] = new SelectList(_context.Peliculas, "Id", "Nombre", funcion.PeliculaId);
            ViewData["SId"] = new SelectList(_context.Salas, "Id", "Numero", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = await _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["SalaId"] = funcion.Sala.Numero.ToString();
            ViewData["PeliculaId"] = funcion.Pelicula.Nombre;
            return View(funcion);
        }

        // POST: Funciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
            return _context.Funciones.Any(e => e.Id == id);
        }

        //public class RestrictedDate : ValidationAttribute
        //{
        //    public override bool IsValid(object date)
        //    {
        //        DateTime fecha = (DateTime)date;
        //        return fecha >= DateTime.Now;
        //    }
        //}

        public IEnumerable<SelectListItem> CrearSelectListPeliculas(IEnumerable<Pelicula> peliculas)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Pelicula pelicula in peliculas)
            {                       
                    {
                        SelectListItem selectItem = new SelectListItem
                        {
                            Text = pelicula.Nombre.ToString(),
                            Value = pelicula.Id.ToString(),
                            Selected = false
                        };
                        selectList.Add(selectItem);
                    }
            }
            return selectList;
        }

        public IEnumerable<SelectListItem> CrearSelectListSalas(IEnumerable<Sala> salas)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Sala sala in salas)
            {
                {
                    SelectListItem selectItem = new SelectListItem
                    {
                        Text = sala.Numero.ToString(),
                        Value = sala.Id.ToString(),
                        Selected = false
                    };
                    selectList.Add(selectItem);
                }

            }
            return selectList;
        }

    }
}

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
            //ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id");
            //ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id");
            ViewData["PeliculaId"] = CrearSelectListPeliculasCreate(_context.Peliculas);
            ViewData["SalaId"] = CrearSelectListSalasCreate(_context.Salas);

            return View();
        }



        // POST: Funciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,SalaId,PeliculaId")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                //Al atributo "TicketsDisponibles" de la clase Funcion asignarle el atributo 
                //capacidad de la clase sala. A traves del atributo SalaId, buscamos el atributo de la 
                //capacidad de la sala.
                _context.Add(funcion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // POST: Funciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Id", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Salas, "Id", "Id", funcion.SalaId);
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

        public IEnumerable<SelectListItem> CrearSelectListPeliculasCreate(IEnumerable<Pelicula> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Pelicula peli in list)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = peli.Nombre,
                    Value = peli.Id.ToString(),
                    Selected = false
                };
                selectList.Add(selectItem);
            }


            return selectList;
        }

        public IEnumerable<SelectListItem> CrearSelectListSalasCreate(IEnumerable<Sala> list)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Sala sala in list)
            {
                SelectListItem selectItem = new SelectListItem
                {
                    Text = sala.Numero.ToString(),
                    Value = sala.Id.ToString(),
                    Selected = false
                };
                selectList.Add(selectItem);
            }


            return selectList;
        }


        public IEnumerable<SelectListItem> CrearSelectListPeliculasUpdate(IEnumerable<Pelicula> list, int id)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Pelicula peli in list)
            {
                SelectListItem selectItem;
                if (peli.Id == id)
                {
                    selectItem = new SelectListItem
                    {
                        Text = peli.Nombre,
                        Value = peli.Id.ToString(),
                        Selected = true
                    };

                }
                else
                {
                    selectItem = new SelectListItem
                    {
                        Text = peli.Nombre,
                        Value = peli.Id.ToString(),
                        Selected = false
                    };
                }
                selectList.Add(selectItem);
            }


            return selectList;

        }

        public IEnumerable<SelectListItem> CrearSelectListSalasUpdate(IEnumerable<Sala> list, int id)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Sala sala in list)
            {
                SelectListItem selectItem;
                if (sala.Id == id)
                {
                    selectItem = new SelectListItem
                    {
                        Text = sala.Numero.ToString(),
                        Value = sala.Id.ToString(),
                        Selected = true
                    };

                }
                else
                {
                    selectItem = new SelectListItem
                    {
                        Text = sala.Numero.ToString(),
                        Value = sala.Id.ToString(),
                        Selected = false
                    };
                }
                selectList.Add(selectItem);
            }


            return selectList;

        }

    }
}

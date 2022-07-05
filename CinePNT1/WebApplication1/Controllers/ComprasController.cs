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
            ViewData["Pelicula"] = pelicula.Nombre;
            ViewData["Fecha"] = funcion.Fecha.ToString();
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
        public IActionResult Create()
        {
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dni,FuncionId,CantidadDeEntradas")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                var funciones = _context.Funciones;
                var funcion = funciones.Find(compra.FuncionId);
                if (validarEntradasDisponibles(funcion.TicketsDisponibles, compra.CantidadDeEntradas))
                {
                    funcion.actualizarTickets(compra.CantidadDeEntradas);
                    _context.Add(compra);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(CompraFinalizada));
                }
                else {
                    ViewData["ErrorTicketsInsuficientes"] = "No hay suficientes entradas para procesar tu pedido";
                    ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id");
                    return View();
                }
                                
            }
           ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", compra.FuncionId);
            return View(compra);
        }

        private bool validarEntradasDisponibles(int ticketsDisponibles, int cantidadEntradas) {
            return cantidadEntradas <= ticketsDisponibles;
        }

        /* NO NECESITAMOS UPDATE NI EDIT 
        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", compra.FuncionId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dni,FuncionId,CantidadDeEntradas")] Compra compra)
        {
            if (id != compra.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.Id))
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
            ViewData["FuncionId"] = new SelectList(_context.Funciones, "Id", "Id", compra.FuncionId);
            return View(compra);
        } */

        // GET: Compras/Delete/5

        //Nuestra clase compra no necesita Delete ni Update
        /*
       public async Task<IActionResult> Delete(int? id)
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

       // POST: Compras/Delete/5
       [HttpPost, ActionName("Delete")]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> DeleteConfirmed(int id)
       {
           var compra = await _context.Compras.FindAsync(id);
           _context.Compras.Remove(compra);
           await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
       } */

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}

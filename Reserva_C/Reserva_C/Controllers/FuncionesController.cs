using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Models;

namespace Reserva_C.Controllers
{
    [Authorize]
    public class FuncionesController : Controller
    {
        private readonly ReservaContext _context;

        public FuncionesController(ReservaContext context)
        {
            _context = context;
        }

        // GET: Funciones
        public IActionResult Index()
        {
            var reservaContext = _context.Funciones;
            return View(reservaContext.ToList());
        }

        // GET: Funciones/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Funciones == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones
                .Include(f => f.Pelicula)
                .Include(f => f.Sala)
                .FirstOrDefault(m => m.Id == id);
            if (funcion == null)
            {
                return NotFound();
            }

            return View(funcion);
        }

        // GET: Funciones/Create
        public IActionResult Create()
        {
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Descripcion");
            ViewData["SalaId"] = new SelectList(_context.Set<Sala>(), "Id", "Id");
            return View();
        }

        // POST: Funciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Fecha,Hora,Descripcion,ButacasDisponibles,Confimrada,SalaId,PeliculaId")] Funcion funcion)
        {
            if (ModelState.IsValid)
            {
                _context.Funciones.Add(funcion);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Set<Sala>(), "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _context.Funciones == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones.Find(id);
            if (funcion == null)
            {
                return NotFound();
            }
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Set<Sala>(), "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // POST: Funciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Fecha,Hora,Descripcion,ButacasDisponibles,Confimrada,SalaId,PeliculaId")] Funcion funcion)
        {
            if (id != funcion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var funcionEnDb = _context.Funciones.Find(funcion.Id);
                    if (funcionEnDb != null)
                    {
                        funcionEnDb.Descripcion = funcion.Descripcion;
                        funcionEnDb.Fecha = funcion.Fecha;
                        funcionEnDb.SalaId = funcion.SalaId;
                        funcionEnDb.Hora = funcion.Hora;
                        funcionEnDb.ButacasDisponibles = funcion.ButacasDisponibles;

                        _context.Funciones.Update(funcionEnDb);
                        _context.SaveChanges();
                    }
                    else
                    { 
                        return NotFound(); 
                    }

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
            ViewData["PeliculaId"] = new SelectList(_context.Peliculas, "Id", "Descripcion", funcion.PeliculaId);
            ViewData["SalaId"] = new SelectList(_context.Set<Sala>(), "Id", "Id", funcion.SalaId);
            return View(funcion);
        }

        // GET: Funciones/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcion = _context.Funciones
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
        public IActionResult DeleteConfirmed(int id)
        {
            var funcion = _context.Funciones.Find(id);
            if (funcion != null)
            {
                _context.Funciones.Remove(funcion);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionExists(int id)
        {
            return _context.Funciones.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Helpers;
using Reserva_C.Models;

namespace Reserva_C.Controllers
{
    [Authorize(Roles = Configs.EmpleadoRolName)]
    public class SalasController : Controller
    {
        private readonly ReservaContext _context;

        public SalasController(ReservaContext context)
        {
            _context = context;
        }

        // GET: Salas
        public IActionResult Index()
        {
            var reservaContext = _context.Salas;
            return View(reservaContext.ToList());
        }

        // GET: Salas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = _context.Salas
                .Include(s => s.TipoSala)
                .FirstOrDefault(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            ViewData["TipoSalaId"] = new SelectList(_context.Set<TipoSala>(), "Id", "Nombre");
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Numero,CapacidadButacas,TipoSalaId")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                _context.Salas.Add(sala);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoSalaId"] = new SelectList(_context.Set<TipoSala>(), "Id", "Nombre", sala.TipoSalaId);
            return View(sala);
        }

        // GET: Salas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = _context.Salas.Find(id);
            if (sala == null)
            {
                return NotFound();
            }
            ViewData["TipoSalaId"] = new SelectList(_context.Set<TipoSala>(), "Id", "Nombre", sala.TipoSalaId);
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Numero,CapacidadButacas,TipoSalaId")] Sala sala)
        {
            if (id != sala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var salaEnDb = _context.Salas.Find(sala.Id);
                    if (salaEnDb != null)
                    {
                        salaEnDb.Numero = sala.Numero;
                        salaEnDb.CapacidadButacas = sala.CapacidadButacas;

                        _context.Salas.Update(salaEnDb);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaExists(sala.Id))
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
            ViewData["TipoSalaId"] = new SelectList(_context.Set<TipoSala>(), "Id", "Nombre", sala.TipoSalaId);
            return View(sala);
        }

        // GET: Salas/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = _context.Salas
                .Include(s => s.TipoSala)
                .FirstOrDefault(m => m.Id == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sala = _context.Salas.Find(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}

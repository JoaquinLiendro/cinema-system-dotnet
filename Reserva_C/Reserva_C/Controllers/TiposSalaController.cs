using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Models;

namespace Reserva_C.Controllers
{
    public class TiposSalaController : Controller
    {
        private readonly ReservaContext _context;

        public TiposSalaController(ReservaContext context)
        {
            _context = context;
        }

        // GET: TiposSala
        public IActionResult Index()
        {
            var reservaContext = _context.TiposSala;
            return View(reservaContext.ToList());
        }

        // GET: TiposSala/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSala = _context.TiposSala
                .FirstOrDefault(m => m.Id == id);
            if (tipoSala == null)
            {
                return NotFound();
            }

            return View(tipoSala);
        }

        // GET: TiposSala/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposSala/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nombre,Precio")] TipoSala tipoSala)
        {
            if (ModelState.IsValid)
            {
                _context.TiposSala.Add(tipoSala);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSala);
        }

        // GET: TiposSala/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSala = _context.TiposSala.Find(id);
            if (tipoSala == null)
            {
                return NotFound();
            }
            return View(tipoSala);
        }

        // POST: TiposSala/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nombre,Precio")] TipoSala tipoSala)
        {
            if (id != tipoSala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.TiposSala.Update(tipoSala);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSalaExists(tipoSala.Id))
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
            return View(tipoSala);
        }

        // GET: TiposSala/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoSala = _context.TiposSala
                .FirstOrDefault(m => m.Id == id);
            if (tipoSala == null)
            {
                return NotFound();
            }

            return View(tipoSala);
        }

        // POST: TiposSala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tipoSala =_context.TiposSala.Find(id);
            if (tipoSala != null)
            {
                _context.TiposSala.Remove(tipoSala);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSalaExists(int id)
        {
            return _context.TiposSala.Any(e => e.Id == id);
        }
    }
}

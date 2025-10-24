using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Helpers;
using Reserva_C.Models;

namespace Reserva_C.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly ReservaContext _context;

        public EmpleadosController(ReservaContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public IActionResult Index()
        {
            return View( _context.Empleados.ToListAsync());
        }

        // GET: Empleados/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado =  _context.Empleados.FirstOrDefaultAsync(m => m.Id == id);
            
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,UserName,Nombre,Apellido,DNI,Telefono,Direccion,Email")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
               
                empleado.Legajo = Generadores.GetNextLegajo(_context); ;
                _context.Add(empleado);
                
                
                _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = _context.Empleados.Find(id);
            if (empleado == null)
            {
                return NotFound();
            }
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UserName,Nombre,DNI,Apellido,Telefono,Direccion,Email")] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var empleadoEnDB = _context.Empleados.Find(id);
                    
                    if (empleadoEnDB != null)
                    {
                        empleadoEnDB.UserName = empleado.UserName;
                        empleadoEnDB.Nombre = empleado.Nombre;
                        empleadoEnDB.Apellido = empleado.Apellido;
                        empleadoEnDB.DNI = empleado.DNI;
                        empleadoEnDB.Telefono = empleado.Telefono;
                        empleadoEnDB.Direccion = empleado.Direccion;
                        empleadoEnDB.Email = empleado.Email;
                       
                        _context.Update(empleadoEnDB);
                        _context.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }

                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Id))
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
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado =  _context.Empleados.FirstOrDefault(m => m.Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
            return _context.Empleados.Any(e => e.Id == id);
        }
    }
}

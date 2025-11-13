using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using Reserva_C.Helpers;
using Reserva_C.Models;

namespace Reserva_C.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly ReservaContext _context;
        private readonly UserManager<Persona> _userManager;

        public ClientesController(ReservaContext context,UserManager<Persona> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        // GET: Clientes
        public  IActionResult Index()
        {
            return View(_context.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Si es un cliente, entonces solamente quiero ver sus propios detalles.
            if (User.IsInRole(Configs.ClienteRolName))
            {
                //solo le voy a mostrar el suyo.
                var usuarioId = Int32.Parse(_userManager.GetUserId(User));

                if (id != usuarioId)
                {
                    return RedirectToAction("Details", new { id = usuarioId });
                }
            }



            var cliente = _context.Clientes.FirstOrDefault(m => m.Id == id);
            
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,UserName,Nombre,Apellido,DNI,Telefono,Direccion,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,UserName,Nombre,Apellido,DNI,Telefono,Direccion,Email")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var clienteEnBD = _context.Clientes.Find(id);
                    
                    if(clienteEnBD == null)
                    {
                        return NotFound();
                    }

                    clienteEnBD.UserName = cliente.UserName;
                    clienteEnBD.Nombre = cliente.Nombre;
                    clienteEnBD.Apellido = cliente.Apellido;
                    clienteEnBD.DNI = cliente.DNI;
                    clienteEnBD.Telefono = cliente.Telefono;
                    clienteEnBD.Direccion = cliente.Direccion;
                    clienteEnBD.Email = cliente.Email;

                    _context.Update(clienteEnBD);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reserva_C.Data;
using Reserva_C.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reserva_C.Controllers
{
    public class PreCarga : Controller
    {
        private readonly UserManager<Persona> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly ReservaContext _context;

        private List<string> roles = new List<string>() { "Admin", "Cliente", "Empleado" };
        public PreCarga(UserManager<Persona> userManager, RoleManager<IdentityRole<int>> roleManager, ReservaContext context) 
        {
            this._userManager = userManager; 
            this._roleManager = roleManager; 
            this._context = context; 
        }
        public IActionResult Seed()
        {
            CrearRoles().Wait();
            CrearAdmin().Wait();
            CrearEmpleados().Wait();
            CrearClientes().Wait();

            return RedirectToAction("Index", "Home", new {mensaje = "Proceso Seed Finalizado"});
        }

        private async Task CrearClientes()
        {
            
        }

        private async Task CrearEmpleados()
        {
            
        }

        private async Task CrearAdmin()
        {
            
        }

        private async Task CrearRoles() 
        {
            foreach(var rolName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(rolName))
                {
                    await _roleManager.CreateAsync(new IdentityRole<int>(rolName));
                }
            }
        }
    }
}

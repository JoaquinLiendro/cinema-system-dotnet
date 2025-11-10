using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Reserva_C.Helpers;
using Reserva_C.Models;
using Reserva_C.Models.ViewModels;
using System.Threading.Tasks;

namespace Reserva_C.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Persona> _usermanager;
        private readonly SignInManager<Persona> _signInManager;
        
        public AccountController(UserManager<Persona> usermanager,SignInManager<Persona> signInManager) {
            this._usermanager = usermanager;
            this._signInManager = signInManager;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegistroUsuario registroUsuario)
        {
            if (ModelState.IsValid)
            {
                Cliente nuevoCliente = new Cliente()
                {
                    Email = registroUsuario.Email,
                    UserName = registroUsuario.Email,
                };

                var resultadoCreate = await _usermanager.CreateAsync(nuevoCliente, registroUsuario.Password);

                if (resultadoCreate.Succeeded) {

                    var resultadoAddRole = await _usermanager.AddToRoleAsync(nuevoCliente, Configs.ClienteRolName);

                    if (resultadoAddRole.Succeeded)
                    {   
                        await _signInManager.SignInAsync(nuevoCliente, isPersistent: false);
                        return RedirectToAction("Edit", "Clientes", new { id = nuevoCliente.Id });
                    }
                    else 
                    {
                        ModelState.AddModelError(string.Empty, $"No se pudo agregar el rol de {Configs.ClienteRolName}");
                    }

            
                }
                
                foreach(var error in resultadoCreate.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

            }

            return View(registroUsuario);
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Login usuario)
        {
            if (ModelState.IsValid)
            {
                var resultado = await _signInManager.PasswordSignInAsync(usuario.Email, usuario.Password, usuario.Recordarme, false);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Inicio de sesion invalida");
                
                
            }

            return View(usuario);
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}

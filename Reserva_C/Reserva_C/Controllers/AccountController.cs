using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                    
                    await _signInManager.SignInAsync(nuevoCliente, isPersistent:false);
                    return RedirectToAction("Index", "Home");
                }
                
                foreach(var error in resultadoCreate.Errors)
                {
                    ModelState.AddModelError(string.Empty,error.Description);
                }

            }

            return View(registroUsuario);
        }
    }
}

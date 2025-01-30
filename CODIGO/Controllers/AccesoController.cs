using Microsoft.AspNetCore.Mvc;
using ProyectoWizard.Data;
using ProyectoWizard.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoWizard.Controllers
{
    public class AccesoController : Controller
    {
        private readonly ProductosDbContext _context;

        public AccesoController(ProductosDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario mod)
        {
            await _context.Usuarios.AddAsync(mod);
            await _context.SaveChangesAsync();

            if (mod.id != 0) {
                return RedirectToAction("Login", "Acceso");
            }
            ViewData["Mensaje"] = "corran todos!!! errro fatal";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Usuario mod)
        {
            Usuario? usuarioEncontrado = await _context.Usuarios
                .Where(u =>
                u.correo == mod.correo &&
                u.clave == mod.clave).FirstOrDefaultAsync();

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "datos incorrectos";
                return View();
            }

            return RedirectToAction("Index", "Producto");
        }

    }
}

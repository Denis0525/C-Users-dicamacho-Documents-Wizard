using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProyectoWizard.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoWizard.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProyectoWizard.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly ProductosDbContext _context;

        public ProductoController(ProductosDbContext context)
        {
            this._context = context;
        }
        public async Task<IActionResult> Login()
        {
            //var result = await _context.Productos.ToListAsync();
            return View();

        }
        public async Task<IActionResult> Index()
        {
            var result = await _context.Productos.ToListAsync();
            return View(result);

        }
        public async Task<IActionResult> Wizar()
        {           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Wizar(Productos mod)
        {
          
            mod.fecha_registro = mod.fecha_registro.ToUniversalTime();

            //await _context
            //    .Set<Productos>()
            //    .AddAsync(mod)
            //    .ConfigureAwait(false);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            _context.Productos.Add(mod);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _context.Productos.FindAsync(id);
            return View(result);
        }

        [HttpPost, ActionName("Eliminar")] 
        public async Task<IActionResult> EliminarId(int id)
        {
            var pro = new Productos()
            {
                id_producto = id
            };

            _context.Productos.Remove(pro);
            await _context.SaveChangesAsync();

            //_context
            //    .Set<Productos>()
            //    .Remove(pro);
            //await _context.SaveChangesAsync().ConfigureAwait(false);
                       
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            var result = await _context.Productos.FindAsync(id);
            return View(result);
        }

        [HttpPost, ActionName("Actualizar")]
        public async Task<IActionResult> ActualizarId(Productos mod)
        {
            mod.fecha_registro = mod.fecha_registro.ToUniversalTime();

            _context.Productos.Update(mod);
            await _context.SaveChangesAsync();

            //_context
            //    .Set<Productos>()
            //    .Update(pro);
            //await _context.SaveChangesAsync().ConfigureAwait(false);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Ver(int id)
        {
            var result = await _context.Productos.FindAsync(id);
            return View(result);
        }
        
        public async Task<ActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToActionPermanent("Login","Acceso");
        }
    }
    
}


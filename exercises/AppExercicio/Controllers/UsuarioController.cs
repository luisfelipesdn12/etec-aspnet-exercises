using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppExercicio.Models;

namespace AppExercicio.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Usuario usuario)
        {
            if (ModelState.IsValid) {
                return View("Resultado", usuario);
            }

            return View(usuario);
        }

        public IActionResult Resultado(Usuario usuario)
        {
            return View(usuario);
        }

        public JsonResult ValidaLogin(string login)
        {   
            var logins = new List<string>{
                "dwight",
                "michael",
                "pam",
                "jim",
                "angela",
                "kevin",
                "oscar",
                "creed",
                "toby",
                "stanley",
                "kelly",
                "ryan",
                "darryl",
            };

            return Json(!logins.Contains(login, StringComparer.OrdinalIgnoreCase));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

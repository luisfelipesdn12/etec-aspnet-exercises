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
            Usuario usuario = new Usuario{
                Id = 1,
                Nome = "Fulano",
                Observacao = "Observação de exemplo, blablabla.",
                DataDeNascimento = DateTime.Now,
                Email = "fulano@detal.com",
                Login = "fulano",
                Senha = "123456",
            };

            return View(usuario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

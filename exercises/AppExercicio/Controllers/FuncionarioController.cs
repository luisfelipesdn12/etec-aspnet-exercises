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
    public class FuncionarioController : Controller
    {
        private readonly ILogger<FuncionarioController> _logger;

        public FuncionarioController(ILogger<FuncionarioController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Funcionario funcionario = new Funcionario{
                Id = 1,
                Nome = "Fulano",
                Cargo = "Professor"
            };

            return View(funcionario);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

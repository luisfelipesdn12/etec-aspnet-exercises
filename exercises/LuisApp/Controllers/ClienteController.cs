using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LuisApp.Models;

namespace LuisApp.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            Cliente cliente = new Cliente{
                Id = 1,
                Nome = "Bela",
                Cpf = 12345678911,
                Rg = 12345678,
                DigRg = '0',
                Telefone = 123456789,
            };

            return View(cliente);
        }
    }
}

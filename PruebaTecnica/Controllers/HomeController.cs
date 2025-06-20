using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;
using System.Diagnostics;

namespace PruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public HomeController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Inicio()
        {
            return View();
        }

    }
}

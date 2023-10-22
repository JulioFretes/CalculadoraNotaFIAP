using CalculadoraNotaFIAP.DataBase;
using CalculadoraNotaFIAP.Extensions;
using CalculadoraNotaFIAP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProductList.Controllers
{
    public class NotaController : Controller
    {
        private CalculadoraContext _context;

        public NotaController(CalculadoraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            var lista = _context.Nota.Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var nota = _context.Nota.Find(id);

            return View(nota);
        }

        [HttpPost]
        public IActionResult Edit(Nota nota)
        {
            nota.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (nota.Calcular)
            {
                decimal valorEsperado = (60m - nota.NotaPrimeiroSemestre) / 0.6m;
                valorEsperado = valorEsperado - (((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m));
                valorEsperado = ((valorEsperado / 0.4m) * 2);
            }

            if (nota.Semestre == SemestreAno.Primeiro)
            {
                nota.Media = Math.Round((((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.4m, 2);
            }
            else if (nota.Semestre == SemestreAno.Segundo)
            {
                nota.Media = Math.Round((((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.6m, 2);
            }

            nota.MediaFinal = Math.Round(nota.Media + nota.NotaPrimeiroSemestre, 2);

            _context.Nota.Update(nota);
            _context.SaveChanges();

            this.ShowMessage("Nota atualizada!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Nota nota)
        {
            nota.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (nota.Calcular)
            {
                decimal valorEsperado = (60m - nota.NotaPrimeiroSemestre) / 0.6m;
                valorEsperado = valorEsperado - (((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m));
                valorEsperado = ((valorEsperado / 0.4m) * 2);
            }

            if (nota.Semestre == SemestreAno.Primeiro)
            {
                nota.Media = Math.Round((((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.4m, 2);
            }
            else if (nota.Semestre == SemestreAno.Segundo)
            {
                nota.Media = Math.Round((((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.6m, 2);
            }

            nota.MediaFinal = Math.Round(nota.Media + nota.NotaPrimeiroSemestre, 2);

            _context.Nota.Add(nota);
            _context.SaveChanges();

            this.ShowMessage("Nota registrada!");

            return RedirectToAction("Register");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var nota = _context.Nota.Find(id);

            _context.Nota.Remove(nota);
            _context.SaveChanges();

            this.ShowMessage("Nota removida!");

            return RedirectToAction("Index");
        }
    }
}

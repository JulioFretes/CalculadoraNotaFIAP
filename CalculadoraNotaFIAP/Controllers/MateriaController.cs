using CalculadoraNotaFIAP.DataBase;
using CalculadoraNotaFIAP.Extensions;
using CalculadoraNotaFIAP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ProductList.Controllers
{
    public class MateriaController : Controller
    {
        private CalculadoraContext _context;

        public MateriaController(CalculadoraContext context)
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

            var lista = _context.Materia
                .Include(t => t.Notas)
                .Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            return View(lista);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var materia = _context.Materia
                .Include(t => t.Notas)
                .First(t => t.Id == id);

            return View(materia);
        }

        [HttpPost]
        public IActionResult Edit(Materia materia)
        {
            materia.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (materia.QuantidadeAulas > 0)
            {
                materia.QuantidadeFaltas = ((int)((materia.QuantidadeAulas * 0.25) - materia.Faltas) / 2);
            }

            foreach (Nota nota in materia.Notas)
            {
                if (nota.Semestre == SemestreAno.Primeiro)
                {
                    if (nota.Cp1 == 0 && nota.Cp2 == 0 && nota.Cp3 == 0 && nota.Sprint1 == 0 && nota.Sprint2== 0 && nota.GlobalSolution == 0)
                    {
                        materia.MediaFinal += (nota.Media * 0.4m);
                    }
                    else
                    {
                        decimal _valorCp = (nota.Cp1 + nota.Cp2 + nota.Cp3) - Math.Min(nota.Cp1, Math.Min(nota.Cp2, nota.Cp3));

                        materia.MediaFinal += Math.Round((((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.4m, 2);
                        nota.Media = Math.Round(((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m), 2);
                    }
                }
                else if (nota.Semestre == SemestreAno.Segundo)
                {
                    if (nota.Cp1 == 0 && nota.Cp2 == 0 && nota.Cp3 == 0 && nota.Sprint1 == 0 && nota.Sprint2 == 0 && nota.GlobalSolution == 0)
                    {
                        materia.MediaFinal += (nota.Media * 0.6m);
                    }
                    else
                    {
                        decimal _valorCp = (nota.Cp1 + nota.Cp2 + nota.Cp3) - Math.Min(nota.Cp1, Math.Min(nota.Cp2, nota.Cp3));

                        materia.MediaFinal += Math.Round((((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.6m, 2);
                        nota.Media = Math.Round(((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m), 2);
                    }
                }
            }

            _context.Materia.Update(materia);
            _context.SaveChanges();

            this.ShowMessage("Matéria atualizada!");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Materia materia)
        {
            materia.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (materia.QuantidadeAulas > 0)
            {
                materia.QuantidadeFaltas = ((int)((materia.QuantidadeAulas * 0.25) - materia.Faltas) / 2);
            }

            materia.Notas[1].Semestre = SemestreAno.Segundo;

            foreach (Nota nota in materia.Notas)
            {
                if (nota.Semestre == SemestreAno.Primeiro)
                {
                    if (nota.Cp1 == 0 && nota.Cp2 == 0 && nota.Cp3 == 0 && nota.Sprint1 == 0 && nota.Sprint2 == 0 && nota.GlobalSolution == 0)
                    {
                        materia.MediaFinal += (nota.Media * 0.4m);
                    }
                    else
                    {
                        decimal _valorCp = (nota.Cp1 + nota.Cp2 + nota.Cp3) - Math.Min(nota.Cp1, Math.Min(nota.Cp2, nota.Cp3));

                        materia.MediaFinal += Math.Round((((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.4m, 2);
                        nota.Media = Math.Round(((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m), 2);
                    }
                }
                else if (nota.Semestre == SemestreAno.Segundo)
                {
                    if (nota.Cp1 == 0 && nota.Cp2 == 0 && nota.Cp3 == 0 && nota.Sprint1 == 0 && nota.Sprint2 == 0 && nota.GlobalSolution == 0)
                    {
                        materia.MediaFinal += (nota.Media * 0.6m);
                    }
                    else
                    {
                        decimal _valorCp = (nota.Cp1 + nota.Cp2 + nota.Cp3) - Math.Min(nota.Cp1, Math.Min(nota.Cp2, nota.Cp3));

                        materia.MediaFinal += Math.Round((((_valorCp + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m)) * 0.6m, 2);
                        nota.Media = Math.Round(((nota.Cp1 + nota.Cp2 + nota.Sprint1 + nota.Sprint2) / 4 * 0.4m) + (nota.GlobalSolution * 0.6m), 2);
                    }
                }
            }

            _context.Materia.Add(materia);
            _context.SaveChanges();

            this.ShowMessage("Matéria registrada!");

            return RedirectToAction("Register");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var materia = _context.Materia.Find(id);

            _context.Materia.Remove(materia);
            _context.SaveChanges();

            this.ShowMessage("Nota removida!");

            return RedirectToAction("Index");
        }
    }
}

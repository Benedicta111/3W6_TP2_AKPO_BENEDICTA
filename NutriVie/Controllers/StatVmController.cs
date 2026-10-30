using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models.Data;
using NutriVie.ViewModel;

namespace NutriVie.Controllers
{
    public class StatVmController : Controller
    {
        private readonly NutriVieDbContext _context;

        public StatVmController(NutriVieDbContext context)
        {
            _context = context;
        }
        public IActionResult StatVm()
        {
            var statsVm = new StatVM(_context.AlimentRecettes.Include(r=>r.Aliment).Include(r=>r.Recette).ToList());
            return View(statsVm);
        }
        public IActionResult AllRecettes()
        {
            List<RecetteCategorieVm> listeCategorie = _context.Categories.Select(c =>
            new RecetteCategorieVm
            {
                Id = c.Id,
                Nom = c.Nom,
                Recettes = c.Recettes.Select(r => new RecetteInfoVm
                {
                    Nom = r.Nom,
                    NbIngrédients = r.AlimentRecettes.Count(),
                    TempsTotal = r.TempsCuisson + r.TempsPreparation
                }).ToList()
            }).ToList();
            return View(listeCategorie);
        }
       
    }
}

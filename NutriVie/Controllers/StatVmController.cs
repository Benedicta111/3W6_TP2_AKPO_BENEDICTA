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
       
    }
}

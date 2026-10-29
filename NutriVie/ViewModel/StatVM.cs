using NutriVie.Models;

namespace NutriVie.ViewModel
{
    public class StatVM
    {
        public StatVM(IEnumerable<AlimentRecette> alimentRecette)
        {

            NbreRecetteAvec3Aliments = alimentRecette.GroupBy(r => r.RecetteId).Count(r => r.Count() == 3);
            AlimentCalorique = alimentRecette.Select(r => r.Aliment).OrderByDescending(r => r.CaloriesPour100g).Select(r => r.Nom).FirstOrDefault();
            RecettesPlusCourtes = alimentRecette.Select(r => r.Recette).OrderBy(r => r.TempsCuisson + r.TempsPreparation).Select(r => r.Nom).Take(4).ToList();
            NbreDeCalorieRecetteFr = 0;/*alimentRecette.Select(r=>r.Recette).Where(r=>r.Categorie.Nom== "Française").OrderBy(r=>r.AlimentRecettes)*/


        }

        public int NbreRecetteAvec3Aliments { get; set; }
        public string AlimentCalorique { get; set; } 
        public List<string> RecettesPlusCourtes { get; set; }
        public int NbreDeCalorieRecetteFr { get; set; }
    }
}

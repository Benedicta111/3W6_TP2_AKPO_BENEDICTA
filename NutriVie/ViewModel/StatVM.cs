using NutriVie.Models;

namespace NutriVie.ViewModel
{
    public class StatVM
    {
        public StatVM(IEnumerable<AlimentRecette> alimentRecette)
        {

            NbreRecetteAvec3Aliments = alimentRecette.GroupBy(r => r.RecetteId).Count(r => r.Count() == 3);
            AlimentCalorique = alimentRecette.Select(r => r.Aliment).OrderByDescending(r => r.CaloriesPour100g).Select(r => r.Nom).FirstOrDefault();
            RecettesPlusCourtes = alimentRecette.GroupBy(r => r.RecetteId).
                Select(r => new RecetteCourteParam
                {
                    Nom=r.First().Recette.Nom,
                    Temps=r.First().Recette.TempsCuisson + r.First().Recette.TempsPreparation
                })
                .OrderBy(r=>r.Temps).Take(4).ToList();
            NbreDeCalorieRecetteFr = alimentRecette.Where(r => r.Recette.CategorieId == 1).GroupBy(r => r.RecetteId).Select(r => r.Sum(r => (r.Poids / 100.0) * r.Aliment.CaloriesPour100g)).Min();


        }

        public int NbreRecetteAvec3Aliments { get; set; }
        public string AlimentCalorique { get; set; }
        public List<RecetteCourteParam> RecettesPlusCourtes = new List<RecetteCourteParam>();
        public double NbreDeCalorieRecetteFr { get; set; }
        public class RecetteCourteParam
        {
            public string Nom { get; set; }
            public int Temps { get; set; }

        }
    }
}

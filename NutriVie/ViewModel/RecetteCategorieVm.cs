namespace NutriVie.ViewModel
{
    public class RecetteCategorieVm
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<RecetteInfoVm> Recettes { get; set; } 
    }
}

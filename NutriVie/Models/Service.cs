using System.ComponentModel.DataAnnotations;

namespace NutriVie.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

    }

}

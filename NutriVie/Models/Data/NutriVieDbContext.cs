using Microsoft.EntityFrameworkCore;

namespace NutriVie.Models.Data
{
    public class NutriVieDbContext : DbContext
    {
        public NutriVieDbContext(DbContextOptions<NutriVieDbContext> options): base(options)
        {

        }

    }
}

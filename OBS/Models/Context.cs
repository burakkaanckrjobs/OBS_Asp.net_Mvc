using Microsoft.EntityFrameworkCore;

namespace Odev.Models
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {

        }
        public DbSet<ilceler> ilceler { get; set; }
        public DbSet<iller> iller { get; set; }
        public DbSet<Ogrenci> Ogrenci_Tbl { get; set; }
        public DbSet<Ogretmen> Ogretmen_Tbl { get; set; }
    }
}

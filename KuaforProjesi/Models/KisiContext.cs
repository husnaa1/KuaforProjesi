

using Microsoft.EntityFrameworkCore;

namespace KuaforProjesi.Models
{
    public class KisiContext : DbContext
    {
        public KisiContext()
        {
        }

        public KisiContext(DbContextOptions<KisiContext> options) : base(options)
        { 
        
        
        }


        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<YöneticiKisiler> YöneticiKisiler { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Fiyat> Fiyat { get; set; }

    }
}

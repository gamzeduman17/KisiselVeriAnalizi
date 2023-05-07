using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VeriAnalizi.Models;

namespace VeriAnalizi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Yorumlar> Yorumlars { get; set; }
        public DbSet<KullaniciMesajEkleme> KullaniciMesajs { get; set; }
        public DbSet<KullaniciSorular> KullaniciSorulars { get; set; }
          
      

      
    }
}
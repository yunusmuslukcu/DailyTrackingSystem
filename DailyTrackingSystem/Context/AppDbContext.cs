using DailyTrackingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace DailyTrackingSystem.Context
{
   
        // DbContext sınıfından miras alıyoruz
        public class AppDbContext : DbContext
        {
            // Bu Constructor, veritabanı bağlantı ayarlarını dışarıdan (Program.cs'den) almamızı sağlar
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

           //Tablolarımızın kuruyoruz!
            public DbSet<Spending> Spendings { get; set; }   //Harcamalar

            public DbSet<Category> Categories { get; set; }  //Kategoriler
    }
    }


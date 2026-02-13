using DailyTrackingSystem.Context;
using DailyTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DailyTrackingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // Dependency Injection ile veritabanı bağlantısını alıyoruz
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Veritabanındaki tüm harcamaları ve kategorileri çekiyoruz
            var spendings = _context.Spendings.Include(x => x.Category).ToList();
            var categories = _context.Categories.Where(x => x.Status).ToList();

            var model = new DashboardViewModel();

            // 1. Toplam Harcama (Sum)
            model.TotalSpending = spendings.Sum(x => x.Amount);

            // 2. En Çok Harcanan Kategori (LINQ GroupBy)
            model.TopCategory = spendings.GroupBy(x => x.Category.Name)
                                .OrderByDescending(g => g.Sum(x => x.Amount))
                                .Select(g => g.Key).FirstOrDefault() ?? "Veri Yok";

            // 3. Bu Ayın Gideri (DateTime Filtreleme)
            model.MonthlySpending = spendings.Where(x => x.Date.Month == DateTime.Now.Month)
                                     .Sum(x => x.Amount);

            // 4. Aktif Kategori Sayısı
            model.ActiveCategoryCount = categories.Count;

            // 5. Son 5 İşlem (ID'ye göre sondan başa)
            model.RecentSpendings = spendings.OrderByDescending(x => x.Id).Take(5).ToList();

            // 6. Bütçe Kontrolü (Örn: 10.000 TL sınır)
            model.IsBudgetExceeded = model.MonthlySpending > 100000;

            return View(model);
        }
    }
}
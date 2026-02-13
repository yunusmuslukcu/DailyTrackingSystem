using DailyTrackingSystem.Context;
using DailyTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DailyTrackingSystem.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Categories.ToList();
            return View(values);
        }

        // İkon listesini hem Get hem Post içerisinde kullanacağımız için merkezi bir yere aldım
        private List<SelectListItem> GetIconList()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = "🏠 Ev Harcaması", Value = "bi bi-house-door" },
                new SelectListItem { Text = "🍔 Yemek Harcaması", Value = "bi bi-egg-fried" },
                new SelectListItem { Text = "🛒 Market Harcaması", Value = "bi bi-cart3" },
                new SelectListItem { Text = "🚗 Yakıt Harcaması", Value = "bi bi-fuel-pump" },
                new SelectListItem { Text = "💡 Fatura Harcaması", Value = "bi bi-lightbulb" },
                new SelectListItem { Text = "📱 İnternet Harcaması", Value = "bi bi-reception-4" },
                new SelectListItem { Text = "🏥 Sağlık Harcaması", Value = "bi bi-heart-pulse" },
                new SelectListItem { Text = "🎓 Eğitim Harcaması", Value = "bi bi-book" },
                new SelectListItem { Text = "🎭 Sosyal Harcaması", Value = "bi bi-controller" },
                new SelectListItem { Text = "👔 Giyim Harcaması", Value = "bi bi-bag-check" },
                new SelectListItem { Text = "🎁 Hediye Harcaması", Value = "bi bi-gift" },
                new SelectListItem { Text = "🔧 Bakım Harcaması", Value = "bi bi-tools" },
                new SelectListItem { Text = "✈️ Seyahat Harcaması", Value = "bi bi-airplane" },
                new SelectListItem { Text = "🏦 Kredi Harcaması", Value = "bi bi-bank" }
            };
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.Icons = GetIconList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            // Kullanıcı sadece Icon seçtiği için, o Icon'un Text değerini bulup Name'e atıyoruz
            var icons = GetIconList();
            var selectedIcon = icons.FirstOrDefault(x => x.Value == category.Icon);

            if (selectedIcon != null)
            {
                category.Name = selectedIcon.Text; // Örn: "🏠 Ev Harcaması"
            }

            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            ViewBag.Icons = GetIconList(); // Güncelleme sayfasında da liste gözükmeli
            var value = _context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            // Güncelleme yaparken de seçilen yeni ikonun metnini Name'e yansıtıyoruz
            var icons = GetIconList();
            var selectedIcon = icons.FirstOrDefault(x => x.Value == category.Icon);

            if (selectedIcon != null)
            {
                category.Name = selectedIcon.Text;
            }

            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
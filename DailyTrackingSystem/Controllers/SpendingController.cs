using DailyTrackingSystem.Context;
using DailyTrackingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DailyTrackingSystem.Controllers
{
    public class SpendingController : Controller
    {
        private readonly AppDbContext _context;

        public SpendingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            // Include kullanarak harcamanın kategori bilgilerini de SQL'den "Join" yaparak çekiyoruz
            var values = _context.Spendings.Include(x => x.Category).ToList();
            return View(values);
        }

        [HttpGet] //Harcama listesi öcenlikle eklemek için getiriliyor!
        public IActionResult CreateSpending()
        {
            // Kategorileri dropdown'a basmak için SelectList oluşturuyoruz
            List<SelectListItem> categoryList = (from x in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.vls = categoryList;
            return View();
        }

        [HttpPost]  //Kullanıcı tarafından girilen veriler ekleniyor ve gönderiliyor!
        public IActionResult CreateSpending(Spending spending)
        {
            _context.Spendings.Add(spending);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Harcama Güncelleme Sayfası
        [HttpGet]
        public IActionResult UpdateSpending(int id)
        {
            // Kategorileri dropdown için tekrar hazırlıyoruz
            List<SelectListItem> categoryList = (from x in _context.Categories.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name,
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.vls = categoryList;

            var value = _context.Spendings.Find(id);
            return View(value);
        }

        // POST: Harcama Güncelleme İşlemi
        [HttpPost]
        public IActionResult UpdateSpending(Spending spending)
        {
            _context.Spendings.Update(spending);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Silme İşlemi
        public IActionResult DeleteSpending(int id)
        {
            var value = _context.Spendings.Find(id);
            _context.Spendings.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DailyTrackingSystem.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string Name { get; set; }

        public string? Icon { get; set; } // Örn: "bi-cart", "fa-home"

        public bool Status { get; set; } = true; // Default olarak aktif

        // Relationship: Bir kategorinin birden fazla harcaması olabilir
        public List<Spending> Spendings { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DailyTrackingSystem.Models
{
    public class Spending
    {
        [Key] // Bu alanın Primary Key (Birincil Anahtar) olduğunu belirtir
        public int Id { get; set; }

        [Required(ErrorMessage = "Açıklama alanı boş geçilemez")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Tutar 0'dan büyük olmalıdır")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        // Navigation Property: Harcamanın hangi kategoriye ait olduğunu tutar
        public Category Category { get; set; }
    }
}

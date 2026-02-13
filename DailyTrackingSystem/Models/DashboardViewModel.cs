namespace DailyTrackingSystem.Models
{
    public class DashboardViewModel
    {
        public decimal TotalSpending { get; set; }  //Toplam Harcama!
        public string TopCategory { get; set; }     //En Çok Kullanılan Kategori!
        public decimal MonthlySpending { get; set; }   //Aylık Harcama!
        public int ActiveCategoryCount { get; set; }   //Aktif Kategori Sayısı!
        public List<Spending> RecentSpendings { get; set; }  //Son Harcama Listesi!

        public bool IsBudgetExceeded { get; set; }  //Bütçe Kontrol!
    }
}

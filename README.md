Harcaman Takipte! 

Günlük harcamalarımı takip etmek için geliştirdiğim bir ASP.NET Core MVC projesi. Kategorilere göre harcama girişi yapabiliyorsun, dashboard üzerinden istatistiklerini görebiliyorsun ve aylık bütçeni kontrol altında tutabiliyorsun.

Proje Hakkında

Bu projeyi .NET tarafında kendimi geliştirmek ve MVC mimarisini daha iyi kavramak için yaptım. Temel CRUD işlemlerinin yanında LINQ sorguları, Entity Framework Code First yaklaşımı ve ilişkisel veritabanı tasarımı gibi konuları pratiğe döktüm.

Ne Yapıyor?

- Dashboard:Toplam harcama, aylık gider, en çok harcama yapılan kategori ve aktif kategori sayısı gibi özet bilgileri kartlar halinde gösteriyor. Son 5 işlemi de tablo olarak listeliyor.
- Bütçe Uyarısı: Aylık harcaman belirlenen limiti aştığında sayfada uyarı çıkıyor.
- Kategori Yönetimi: Yeni kategoriler ekleyebilir, mevcut kategorileri güncelleyebilir veya silebilirsin. Her kategoriye Bootstrap Icons üzerinden ikon atanıyor (ev, market, yemek, yakıt vb.).
- Harcama Yönetimi: Harcama eklerken açıklama, tutar ve kategori seçimi yapıyorsun. Eklenen harcamaları listeleyebilir, güncelleyebilir veya silebilirsin.

Kullanılan Teknolojiler

 .NET 8.0
 ASP.NET Core MVC 8.0 
 Entity Framework Core 8.0 
 SQL Server Express  
 Bootstrap 5.x 
 Bootstrap Icons 1.11.3 
 jQuery 3.x 

Öne Çıkan Teknik Detaylar

- Code First Yaklaşımı; Modelleri oluşturup migration ile veritabanını otomatik oluşturdum.
- LINQ Sorguları: Dashboard'daki istatistikler için GroupBy, Sum, OrderByDescending, Where gibi LINQ metotlarını kullandım.
- Include ile Eager Loading: Harcamaları listelerken ilişkili kategori bilgisini Include() ile birlikte çekiyorum.
- Dependency Injection: Controller'larda AppDbContext'i constructor injection ile alıyorum.
- ViewBag & SelectList: Dropdown listeler için ViewBag ve SelectListItem kullandım.
- Responsive Tasarım: Bootstrap grid sistemi ve card yapısı ile responsive bir arayüz oluşturdum.



Gereksinimler

- .NET 8 SDK
- SQL Server veya SQL Server Express
- Visual Studio 2022 / VS Code


Öğrendiklerim

Bu projeyi geliştirirken şu konularda pratik yaptım:

- ASP.NET Core MVC mimarisi (Controller - View - Model)
- Entity Framework Core ile Code First veritabanı yönetimi
- LINQ ile veritabanı sorguları ve raporlama
- Bootstrap ile responsive ve modern UI tasarımı
- Dependency Injection prensibi
- Data Annotation'lar ile model validasyonu

Lisans

Bu proje öğrenme amaçlı geliştirilmiştir.



**Geliştirici:** Yunus Muslukcu

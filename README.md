# 🏡 Villa Projesi - Modern Villa Tanıtım & Yönetim Sistemi

Bu proje, modern bir villa kiralama veya satış platformu için geliştirilmiş, kapsamlı bir web uygulamasıdır. .NET 8.0 ASP.NET Core MVC mimarisi üzerine inşa edilmiş olup, veritabanı olarak MongoDB kullanmaktadır.

## 🚀 Teknolojiler

Proje geliştirilirken kullanılan temel teknolojiler ve kütüphaneler:

*   **Framework:** .NET 8.0 (ASP.NET Core MVC)
*   **Veritabanı:** MongoDB (NoSQL)
*   **Mimari:** N-Tier Architecture (Çok Katmanlı Mimari)
    *   **Villa.WebUI:** Sunum Katmanı
    *   **Villa.Business:** İş Mantığı Katmanı
    *   **Villa.DataAccess:** Veri Erişim Katmanı
    *   **Villa.Entity:** Veri Modelleri
    *   **Villa.Dto:** Veri Transfer Nesneleri
*   **Tasarım Desenleri:** Generic Repository Pattern, Service Pattern
*   **Frontend:** HTML5, CSS3, JavaScript, Bootstrap
*   **Kimlik Doğrulama:** ASP.NET Core Identity (MongoDB Entegrasyonu)

## ✨ Özellikler

Uygulama hem son kullanıcıya hitap eden bir ön yüze hem de içeriklerin yönetilebileceği gelişmiş bir admin paneline sahiptir:

*   **Dinamik Ana Sayfa:** Banner, alt başlık ve özellikler bölümleri admin panelinden yönetilebilir.
*   **Villa (Ürün) Yönetimi:** Villaların listelenmesi, detaylarının görüntülenmesi ve yönetimi.
*   **İletişim & Mesajlaşma:** Ziyaretçilerin mesaj gönderebileceği iletişim formu ve bu mesajların admin panelinden takibi.
*   **İstatistikler:** Sayaç (Counter) bölümü ile dinamik veri gösterimi.
*   **Video & Galeri:** Proje tanıtım videolarının ve görsellerinin yönetimi.
*   **Admin Paneli:** Tüm içeriklerin (Banner, Fırsatlar, Sorular, Ürünler vb.) CRUD işlemlerinin yapılabildiği merkezi yönetim alanı.
*   **Güvenli Giriş:** Identity sistemi ile güvenli kullanıcı girişi ve yetkilendirme.

## 🛠️ Kurulum

Projeyi yerel bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyebilirsiniz:

1.  **Depoyu Klonlayın:**
    ```bash
    git clone https://github.com/Seyma12408/VillaProjesiFinal.git
    ```
2.  **Veritabanı Yapılandırması:**
    `Villa.WebUI/appsettings.json` dosyasındaki MongoDB bağlantı adresini (Connection String) kendi MongoDB Atlas veya yerel bağlantınızla güncelleyin:
    ```json
    "MongoDbSettings": {
      "Connection": "YOUR_MONGODB_CONNECTION_STRING",
      "DatabaseName": "VillaDb"
    }
    ```
3.  **Projeyi Çalıştırın:**
    Visual Studio üzerinden `Villa.WebUI.sln` dosyasını açın ve `Villa.WebUI` projesini başlangıç projesi olarak ayarlayıp çalıştırın (F5).

## 📂 Klasör Yapısı

*   `DataAccess/`: Veritabanı bağlantı ayarları ve repository implementasyonları.
*   `Villa.Business/`: İş kuralları, validasyonlar ve servisler.
*   `Villa.Entity/`: Veritabanı tablolarına karşılık gelen sınıflar.
*   `Villa.WebUI/`: Controller, View ve UI dosyaları.
*   `Villa.Dto/`: Katmanlar arası veri taşıma nesneleri.

---
<img width="1887" height="850" alt="Ekran görüntüsü 2026-05-09 165811" src="https://github.com/user-attachments/assets/3211991e-c8e9-47e9-9ec3-e9df13c7aaba" />
<img width="1828" height="852" alt="Ekran görüntüsü 2026-05-09 165850" src="https://github.com/user-attachments/assets/b14ee0c7-6dc5-49d6-9156-c23a3cc9ac71" />
<img width="1858" height="848" alt="Ekran görüntüsü 2026-05-09 165938" src="https://github.com/user-attachments/assets/1f94d7e8-2a6c-4e38-b959-d4c9669ec20d" />
<img width="1398" height="778" alt="Ekran görüntüsü 2026-05-09 170041" src="https://github.com/user-attachments/assets/d29b7355-90cd-46a9-a97d-3242ad4d4c0c" />


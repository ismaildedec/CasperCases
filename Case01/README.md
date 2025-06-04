# 🛒 ProductApi – Ürün Listeleme ve Filtreleme API'si

## 🎯 Proje Amacı

Bu proje, mock verilerle çalışan basit bir ürün listeleme ve filtreleme API’si geliştirmek amacıyla oluşturulmuştur.  
API, `GET` metodunu kullanarak ürünlerin listelenmesini ve istenirse ürün adı veya kategorisine göre filtrelenmesini sağlar.

---

## 📁 Proje Yapısı

ProductApi/
├── Controllers/
│ └── ProductController.cs
├── Models/
│ └── Product.cs
├── Services/
│ ├── IProductService.cs
│ └── ProductService.cs
├── Data/
│ └── MockData.cs
├── DTOs/
│ └── ProductFilterDto.cs
└── Program.cs


---

## 📦 `Models/Product.cs`

• Product model sınıfı burada tanımlıdır.  
• Özellikler: `Id`, `Name`, `Category`  
• Her property XML dokümantasyonu ile açıklanmıştır.  
• Basit veri modellemesi ile anlaşılır ve genişletilebilir bir yapı sunar.

---

## 📤 `DTOs/ProductFilterDto.cs`

• API’ye gelen `filter` query parametresini karşılayan veri transfer objesi.  
• `filter` alanı sayesinde ürün adı ya da kategoriye göre filtreleme yapılabilir.  
• XML yorumları ile Swagger UI’de detaylı açıklama sağlanır.

---

## 📚 `Data/MockData.cs`

• Uygulama içinde statik olarak tanımlanmış mock veri kaynağıdır.  
• Ürün listesi:  
  - Laptop (Elektronik)  
  - Telefon (Elektronik)  
  - Koltuk (Mobilya)  
  - Masa (Mobilya)  
  - Kazak (Giyim)

---

## 🔧 `Services/IProductService.cs`

• Ürünlerle ilgili servis arayüzü.  
• Metotlar:  
  - `Task<List<Product>> GetAllProductsAsync();`  
  - `Task<List<Product>> GetFilteredProductsAsync(string? filter);`  
• SOLID prensiplerinden **Interface Segregation Principle** uygulanmıştır.

---

## ⚙️ `Services/ProductService.cs`

• Mock veriler üzerinde filtreleme ve listeleme mantığını uygular.  
• Filtreleme işlemleri hem ürün adı hem kategoriye göre, büyük-küçük harf duyarsız yapılır.  
• `async/await` ile asenkron yapı sağlanmıştır.  
• Kod okunabilirliği ve test edilebilirliği için temiz servis yapısı izlenmiştir.

---

## 🌐 `Controllers/ProductController.cs`

• Ana API endpoint’lerini sunan controller sınıfı.  
• Route: `/api/product`  
• `GET` metodunu kullanır.  
• `filter` parametresiyle opsiyonel arama yapılabilir.  
• Hata yönetimi `try-catch` bloklarıyla sağlanmıştır.  
• `ProducesResponseType` attribute’ları ile olası response durumları tanımlanmıştır.  
• Dependency Injection ile `IProductService` kullanılmıştır.

---

## 🏁 `Program.cs`

• Servis bağımlılıkları: `AddScoped<IProductService, ProductService>()`  
• Swagger konfigürasyonu:  
  - Başlık: **ProductApi**  
  - Versiyon: **v1**  
  - Açıklama: Ürün listeleme ve filtreleme API’si  
• CORS yapılandırması tüm kaynaklara açık olarak ayarlanmıştır (`AllowAnyOrigin`).  
• `Console.WriteLine` ile başlatma mesajı verilmiştir.  
• Kod, `#region`’lar ile organize edilmiştir.

---

## 🔍 API Kullanımı
Tüm Ürünleri Listele 
```bash
GET /api/product
```


## 🔎 Filtreleme (İsteğe Bağlı)

GET /api/product?filter=laptop

---

## 🚀 Başlatma

1. Projeyi Visual Studio veya VS Code ile açın.
2. Terminalden aşağıdaki komutu çalıştırın:

```bash
dotnet run
```

---

## 📸 Swagger UI

Projeyi çalıştırdıktan sonra Swagger arayüzüne şu adresten erişebilirsiniz:

```bash
https://localhost:{port}/swagger/index.html
```
---
## 🧪 Test Senaryoları

| Senaryo            | URL                           | Açıklama                      |
| ------------------ | ----------------------------- | ----------------------------- |
| Tüm ürünleri getir | `/api/product`                | Tüm ürünleri listeler         |
| "mobilya" filtresi | `/api/product?filter=mobilya` | Kategoriye göre filtreleme    |
| "masa" filtresi    | `/api/product?filter=masa`    | Ürün adına göre filtreleme    |
| Büyük/küçük harf   | `/api/product?filter=LAPTOP`  | Case-insensitive arama sağlar |

---

## 🧱 Kullanılan Teknolojiler

- .NET 6  
- C#  
- Swagger (Swashbuckle.AspNetCore)  
- Bağımlılık Enjeksiyonu (Dependency Injection)  
- Asenkron Programlama (async/await)  
- RESTful API  
- SOLID Prensipleri  
- CORS Desteği  
- XML Dokümantasyonu  
- Temiz Mimari (Clean Architecture) Yaklaşımı  
- Try-Catch ile Hata Yönetimi  

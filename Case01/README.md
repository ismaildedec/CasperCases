ProductApi – Ürün Listeleme ve Filtreleme API'si

 Proje Tanımı 


   Mock verilerle çalışan basit bir ürün listeleme ve filtreleme API’si geliştirmek amacıyla oluşturulmuştur. API, GET metodunu kullanarak ürünlerin listelenmesini ve istenirse ürün adı veya kategorisine göre filtrelenmesini sağlar.


📁 Proje Yapısı


  ProductApi/
├── Controllers/
│   └── ProductController.cs
├── Models/
│   └── Product.cs
├── Services/
│   ├── IProductService.cs
│   └── ProductService.cs
├── Data/
│   └── MockData.cs
├── DTOs/
│   └── ProductFilterDto.cs
└── Program.cs

📦 Models/Product.cs


Product model sınıfı burada tanımlıdır.

Özellikler: Id, Name, Category

Her property XML dokümantasyonu ile açıklanmıştır.

Basit veri modellemesi ile anlaşılır ve genişletilebilir bir yapı sunar.


📤 DTOs/ProductFilterDto.cs


API’ye gelen filter query parametresini karşılayan veri transfer objesi.

filter alanı sayesinde ürün adı ya da kategoriye göre filtreleme yapılabilir.

XML yorumları ile Swagger UI’de detaylı açıklama sağlanır.




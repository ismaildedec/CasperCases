ProductApi

Proje Hakkında Açıklama :
  Bu proje, C# .NET 7 Web API kullanılarak geliştirilmiş basit bir ürün listeleme ve filtreleme API'sidir. Veriler mock (bellekte sabit) olarak tutulur, herhangi bir veritabanı bağlantısı yoktur.
Proje Kullanımı:
  - API sadece GET metodunu destekler.
  - /product endpoint'ine istek atıldığında tüm ürünler JSON olarak döner.
  - ?filter= query parametresi ile ürün adı veya kategoriye göre filtreleme yapılabilir.
    - Örnek: /product?filter=elektronik 
Geliştirme Notları:
  - Proje sade ve okunabilir olacak şekilde, ek servis katmanları olmadan tek controller üzerinden yazılmıştır.
  - Ürünler ve model doğrudan controller içinde tanımlanmıştır.
  - WeatherForecast ile ilgili varsayılan dosyalar silinmiştir.
Proje Çalıştırma:
  1. Proje klasöründe terminal açın.
  2. dotnet run komutunu çalıştırın.
  3. Tarayıcıdan http://localhost:port/product adresine GET isteği atarak sonucu görebilirsiniz.
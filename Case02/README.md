# 📃 Ürün Yönetimi Sistemi (Product Management System)

Bu proje, **.NET 8 Web API** ve **React 18** kullanarak geliştirilmiş kapsamlı bir ürün yönetimi sistemidir. CRUD işlemleri, kategori yönetimi ve responsive frontend arayüz içerir.

---

## 🗋 Proje Genel Bakış

### Case Gereksinimleri

- ✅ .NET teknolojileri ile REST API geliştirme
- ✅ Ürün CRUD operasyonları (Oluşturma, Güncelleme, Silme, Listeleme)
- ✅ Kategori sistemi entegrasyonu
- ✅ Modern ve responsive frontend arayüz

### Teknoloji Stack

| Katman     | Teknoloji                      |
|------------|--------------------------------|
| Backend    | .NET 8 Web API                 |
| Frontend   | React 18 + Vite                |

---

## 🏗️ Proje Yapısı

```bash
Case02/
├── backend/
│   └── ProductApi/
│       ├── Controllers/
│       │   └── ProductController.cs     # Ana API controller
│       ├── Program.cs                   # Uygulama girişi ve config
│       ├── appsettings.json            # Genel ayarlar
│       └── appsettings.Development.json # Geliştirme ayarları
└── frontend/
    ├── src/
    │   └── App.jsx                     # Ana React component
    ├── package.json                    # Frontend bağımlılıkları
    └── vite.config.js                  # Vite yapılandırması
```

## 🔧 Backend Detayları

### Program.cs

- **CORS Policy**
- **Swagger dokümentasyonu**
- **Endpoint mapping**

### ProductController.cs

#### API Endpoints

| Method | Endpoint                  | Açıklama                                     |
|--------|---------------------------|----------------------------------------------|
| GET    | `/Products`               | Tüm ürünleri kategori bilgileriyle listeler |
| POST   | `/Products`               | Yeni ürün ekler                              |
| PUT    | `/Products/{id}`          | Ürün günceller                               |
| DELETE | `/Products/{id}`          | Ürün siler                                   |
| GET    | `/Products/categories`    | Tüm kategorileri listeler                    |


---

## 🎨 Frontend Detayları

### Ana Component: `App.jsx`

#### State Management

- `products`
- `categories`
- `editingProduct`
- `formData`

#### Özellikler

- Real-time CRUD işlemleri  
- Form validation  
- Responsive design    
- Silme onay diyaloğu   

---

## 🚀 Kurulum ve Çalıştırma

### Gereksinimler

- .NET 8 SDK  
- Node.js (18+)  
- npm veya yarn  
---
### Backend Çalıştırma

```bash
cd backend/ProductApi
dotnet restore
dotnet run
# http://localhost:5268
```
---
### Frontend Çalıştırma

```bash
cd frontend
npm install
npm run dev
# http://localhost:5173
```
---


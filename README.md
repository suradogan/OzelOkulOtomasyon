## OkulOtomasyon

### Genel Bakış
OkulOtomasyon, bir okulun temel süreçlerini (öğrenci, öğretmen, veli yönetimi ve not işlemleri) yönetmek için geliştirilen Windows Forms tabanlı bir masaüstü uygulamasıdır. Uygulama DevExpress WinForms bileşenleri ile modern bir şerit (Ribbon) arayüz ve zengin grid bileşenleri sunar. Veri erişim katmanında hem ADO.NET (SqlClient) hem de Entity Framework 6 (Database-First, EDMX) kullanılmaktadır.

- **Platform**: .NET Framework 4.7.2 (WinForms)
- **UI**: DevExpress WinForms 24.2
- **ORM**: Entity Framework 6.5.1 (Database-First, `OkulModel.edmx`)
- **Veritabanı**: Microsoft SQL Server (Integrated Security)

### Ekranlar ve Modüller
- **Giriş (FrmGiris)**: Yönetici, öğretmen ve öğrenci girişi. Parametreli SQL sorguları ile doğrulama. Başarılı girişte ana modüle veya öğrenci not listeleme ekranına yönlendirme.
- **Ana Modül (Form1 / FrmAnaModul)**: DevExpress Ribbon ile MDI yapıda modüllere (öğretmenler, öğrenciler, veliler, ayarlar, not giriş) erişim.
- **Öğrenciler (FrmOgrenciler)**: 5–8. sınıflar bazında listeleme, CRUD, resim yönetimi (`resimler` klasörü). Grid odak değişiminde form alanlarını doldurma.
- **Öğretmenler (FrmOgretmenler)**: Listeleme, CRUD, branş ve il seçimi, resim ekleme.
- **Veliler (FrmVeliler)**: Listeleme, ekleme/güncelleme/silme.
- **Not Girişi (FrmNotGiris)**: Sınıf ve öğrenci seçerek sınav/sözlü notları girme, ortalama hesaplama, listeleme.
- **Not Listeleme (FrmNotListele)**: Öğrencinin kendi TC’sine göre notlarını görüntüleme, Excel/PDF dışa aktarma.
- **Ayarlar (FrmAyarlar)**: Öğretmen/öğrenci şifre işlemleri, öğretmen ve öğrenci seçim listeleri. ADO.NET + EF karışık kullanım.

### Mimari ve Teknoloji Yığını
- **Sunum Katmanı**: WinForms (DevExpress Ribbon, Grid, Editors), MDI yapı.
- **Veri Erişimi**:
  - Entity Framework 6 EDMX (`OkulModel.edmx`): `DbOkulEntities` bağlamı, tablolar ve ilişkiler. `OnModelCreating` üzerinde `UnintentionalCodeFirstException()` ile Database-First garantisi.
  - ADO.NET (System.Data.SqlClient): Performans veya özel sorgular için doğrudan SQL kullanımı.
- **Bağımlılıklar**:
  - `EntityFramework` 6.5.1 (NuGet)
  - DevExpress WinForms 24.2 kütüphaneleri (Data, Utils, XtraBars, XtraEditors, XtraGrid, XtraLayout, XtraPrinting vb.)

### Dizin Yapısı (özet)
- `OkulOtomasyon.sln`: Visual Studio çözümü
- `OkulOtomasyon/OkulOtomasyon.csproj`: Proje dosyası (.NET Framework 4.7.2)
- `OkulOtomasyon/Program.cs`: Uygulama girişi (`Application.Run(new FrmGiris())`)
- `OkulOtomasyon/App.config`: EF sağlayıcı ve `DbOkulEntities` bağlantı dizesi
- `OkulOtomasyon/OkulModel.edmx`: EF Database-First model
- `OkulOtomasyon/resimler/`: Uygulama içinde kullanılan görseller
- `OkulOtomasyon/Frm*.cs`: Ekran/form kodları
- `OkulOtomasyon/sqlbaglantisi.cs`: ADO.NET bağlantı sınıfı (tek sorumluluk)

### Veritabanı
- **Bağlantı** (App.config):
```xml
<connectionStrings>
  <add name="DbOkulEntities"
       connectionString="metadata=res://*/OkulModel.csdl|res://*/OkulModel.ssdl|res://*/OkulModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ŞURANIN_ADINI_DEĞİŞTİRİN;initial catalog=dbo.OkulOtomasyon;integrated security=True;encrypt=True;trustservercertificate=True;MultipleActiveResultSets=True;App=EntityFramework&quot;"
       providerName="System.Data.EntityClient" />
</connectionStrings>
```
- **Öne çıkan tablolar**: `TBL_OGRENCILERR`, `TBL_OGRETMENLER`, `TBL_VELILER`, `TBL_BRANSLAR`, `TBL_OGRAYARLAR`, `TBL_OGRTAYARLAR`, `IllerTablosu`, `sysdiagram`.
- **Uygulamada geçen ve veritabanınızda bulunması gereken ek tablolar**:
  - `TBL_YONETICI` (FrmGiris yönetici girişi için)
  - `TBL_NOTGİRİS` (FrmNotGiris/FrmNotListele için; tablo adında Türkçe karakter bulunmaktadır)
- **Saklı yordamlar**: `AyarlarOgrenciler`, `AyarlarOgretmenler` (Ayarlar ekranı listeleri için kullanılıyor).

Not: Proje Database-First yaklaşımı kullanır. Şemanız değiştiğinde Visual Studio’daki EDMX tasarımcısından “Update Model from Database…” ile modeli güncelleyiniz.

### Kurulum
1. **Gereksinimler**
   - Windows 10/11
   - Visual Studio 2022 (v17+)
   - .NET Framework 4.7.2 geliştirici paketleri
   - SQL Server (Express veya üstü)
   - DevExpress WinForms 24.2 (lisanslı kurulum veya NuGet feed)
2. **Projeyi Açma**
   - `OkulOtomasyon.sln` dosyasını Visual Studio ile açın.
   - NuGet paketlerini geri yükleyin (EF 6.5.1 otomatik gelecektir).
   - DevExpress başvuruları için aynı sürümün (24.2.x) yüklü olduğundan emin olun.
3. **Veritabanı Ayarları**
   - `App.config` içindeki `DbOkulEntities` bağlantısındaki `data source` ve `initial catalog` değerlerini kendi ortamınıza göre düzenleyin.
   - Gerekli tabloları ve saklı yordamları oluşturun (yukarıdaki listelere bakınız). EDMX şemasını veritabanınız ile hizalayın.
4. **Çalıştırma**
   - Başlangıç projesi `OkulOtomasyon` olarak ayarlanmış olmalı.
   - `F5` ile çalıştırın. Açılış ekranı `FrmGiris` gelecektir.

### Kullanım Akışı (Özet)
- Yönetici/Öğretmen/Öğrenci girişini `FrmGiris` üzerinden yapın.
- Yönetici/Öğretmen için `Form1` (Ana Modül) açılır. İlgili modül butonları ile kayıtları yönetebilirsiniz.
- Öğrenciler, kendi TC numarası ile giriş yapıp `FrmNotListele` ekranında notlarını görüntüleyebilir, Excel/PDF dışa aktarabilir.

### Güvenlik ve En İyi Uygulamalar
- Parolalar şu an düz metin olarak saklanmaktadır. Üretim ortamı için şunlar önerilir:
  - Parola saklama: BCrypt/Argon2 ile hash (salt’lı) saklama.
  - Yetkilendirme: Rol bazlı erişim kontrolü.
  - Bağlantı dizesi: Güvenli gizleme (User Secrets, ortam değişkeni veya şifreli depolama).
- SQL: Kodlarda parametreli sorgular kullanılmaktadır; yine de giriş doğrulamalarını kuvvetlendirin.

### Dosya/Yol Yönetimi
- Resim klasörü `resimler` altında tutulur. `FrmOgrenciler` dinamik yol kullanır (`Application.StartupPath`).
- Bazı ekranlarda (örn. `FrmOgretmenler`, `FrmAyarlar`) tam yol sabitleri mevcuttur. Kurulum sonrasında bu yolları ortamınıza göre düzenleyin veya merkezi bir yol sağlayıcısı ile tekilleştirin.

### Sık Karşılaşılan Sorunlar
- “DevExpress … bulunamadı” veya sürüm uyuşmazlığı: DevExpress 24.2 aynı minör sürümde kurulu olmalı; `licenses.licx` dosyasını derleme sırasında çözmek için lisansınız etkin olmalı.
- Veritabanına bağlanamama: `App.config` bağlantı dizesini sunucu adı ve veritabanı adına göre güncelleyin. Gerekirse `encrypt`/`trustservercertificate` değerlerini kurum politikanıza göre ayarlayın.
- EDMX senkron: Şema değişikliklerinde “Update Model from Database…” yapmayı unutmayın.
- Türkçe karakterli tablo/kolon adları: Sunucu kolation ayarlarına bağlı olarak sorgularda eşleşme sorunları yaşanabilir; tutarlılık sağlayın.

### Yol Haritası (Öneriler)
- Parola saklama ve kimlik doğrulama iyileştirmeleri
- Resim yol yönetiminin merkezileştirilmesi ve kullanıcı klasörlerine göre relativizasyon
- Birim testleri ve temel entegrasyon testleri
- EF’de Code-First veya EF Core’a göç (uzun vadeli)
- Loglama (Serilog/NLog) ve hata raporlama


# Fabrika Envanter Yönetim Sistemi

## 🎯 Projenin Amacı

Fabrikaların envanter kontrolünü sağlayan bir **web sitesi geliştirilmesi** hedeflenmektedir. Sistem, bir firmanın **birden fazla fabrika ekleyebilmesine** olanak tanıyacak, fabrikalara bağlı **binalar** ve bu binalara ait **depolar** tanımlanabilecektir.

👥 **Admin ve personel kullanıcı rolleri** üzerinden envanter yönetimi sağlanacaktır. Personel; fabrikaya yeni **malzemeler ekleyebilecek**, bu malzemeleri **depolara aktarabilecek** veya **depolardan çıkarabilecektir**.

📦 Depodaki malzemelerin miktarını takip eden personel, bir ürünün azaldığını fark ettiğinde **talep oluşturabilecektir**. Oluşturulan talepler **admin tarafından onaylanabilecek veya reddedilebilecektir**.

📊 Sistem ayrıca, **hangi malzemeyi kimin, hangi tarihte ve hangi depoya eklediği ya da çıkardığına dair detaylı analizlerin** yer aldığı bir analiz sayfası sunacaktır.

🔎 Bunun yanında, malzemelerin **hangi depolarda bulunduğu** ve **toplam envanter miktarları** da sistem üzerinden görüntülenebilecektir.

🏭 Bu proje, fabrikaların envanter süreçlerini **daha düzenli, şeffaf ve verimli** bir şekilde yönetmelerine olanak sağlamayı amaçlamaktadır.

## 🛠️ Kullanılan Teknolojiler

Projede aşağıdaki teknolojiler kullanılmıştır:

- ⚙️ **ASP.NET Core MVC**
- 🗄️ **Entity Framework**
- 🎨 **Bootstrap**
- 💾 **MSSQL**

## 🗄️ Veri Tabanı Diyagramı

<img width="1262" height="662" alt="image" src="https://github.com/user-attachments/assets/6d1e10fa-b6b4-4e25-a2ce-1d2758f6b574" />

📊 Bu diyagram, sistemde kullanılan veritabanı tablolarını ve tablolar arasındaki ilişkileri göstermektedir.


## 🧱 Katmanlı Mimari

<p align="center">
  <img width="400" alt="image" src="https://github.com/user-attachments/assets/d3a2afec-e806-4afc-b794-f6c1b3d6957e" />
</p>

📦 Projede **katmanlı mimari** kullanılmıştır.  
Sistem aşağıdaki katmanlardan oluşmaktadır:

- **Business Katmanı**
- **Core Katmanı**
- **DataAccess Katmanı**
- **Dto Katmanı**
- **Entities Katmanı**
- **MvcWebUI Katmanı**



## 🖥️ Web Sitesi Ana Sayfa

<img width="1304" height="595" alt="image" src="https://github.com/user-attachments/assets/929e80fd-0a05-443b-bb3c-78b846795fd2" />

📌 Sidebar menüde profil, kayıt, talepler, analiz, tüm ürünler, fabrikalar, ekle menüsü, yeni ürün ekle ve depoya ürün ekle butonları bulunmaktadır.  

👤 Kayıt kısmında adminler personel ve admin kaydı yapabilir.  

🏭 Admin ekle butonuyla fabrika, bina ve depo ekleyebilir.

## 🏭 Fabrika Binaları Görüntülenmesi

<img width="1561" height="442" alt="image" src="https://github.com/user-attachments/assets/789070c1-c239-4df6-9163-897573aed8b4" />

🏢 Fabrikaya ait binaları görüntüleyebilir ve binaları silebilirsiniz.  

📦 Her bir binanın depolarını görmek için **Depoları Göster** butonu ile depoları görüntüleyebilirsiniz.

## 📦 Depodaki Malzemeler

<img width="1565" height="673" alt="image" src="https://github.com/user-attachments/assets/a5f42516-8111-44b1-8c89-07c93685ccbd" />

📋 Devre deposundaki malzemeler görüntülenmektedir.  

🔢 Bu depodaki toplam malzeme sayısı en alt kısımda verilmiştir.  

➕➖ Depodan malzeme çıkarabilir, ekleyebilir veya eksik malzeme var ise talep oluşturabilirsiniz.  

🔎 Ayrıca depoda ürün ismine göre arama yapılabilir.


## 🧾 Devre Kartı Depo Bilgisi

<img width="1567" height="464" alt="image" src="https://github.com/user-attachments/assets/23536b10-297f-4d66-9c20-e1d513f4ca9f" />

🖱️ Malzemenin üzerine tıklanarak bu malzemenin hangi depolarda bulunduğu tespit edilebilir.  

📊 Ayrıca bu malzemenin tüm depolardaki **toplam stok miktarı** görüntülenebilir.


## 📑 Talepler Sayfası

<img width="1564" height="865" alt="image" src="https://github.com/user-attachments/assets/14d4c138-22e1-4c1a-b3d9-d1bf283b05d1" />

📌 Talepler sayfasında personeller tarafından oluşturulan talepler admin tarafından **onaylanabilir veya reddedilebilir**.

📊 Ayrıca **onay durumu, onay tarihi, talebi kimin yaptığı, hangi malzemeden kaç adet talep oluşturulduğu** gibi bilgiler bu sayfada görüntülenebilir.

🔎 Sayfa filtreleme yöntemi ile **sadece onay bekleyen, reddedilen veya onaylanan talepler** listelenebilir.

## 📊 Analiz Sayfası

<img width="1568" height="864" alt="image" src="https://github.com/user-attachments/assets/f02c9034-58bb-4159-933d-ed9e7e000303" />

📈 Analiz sayfasında hangi kullanıcının hangi üründen kaç adet eklediği veya çıkardığı ve bu işlemi hangi zamanda yaptığı görüntülenebilir.

🏭 Ayrıca işlemin **hangi bina ve hangi depo üzerinde yapıldığı** gibi detaylı analizler de görüntülenebilir.

❌ Bunun yanında **talepler sayfasında reddedilen işlemler** de bu sayfada analiz olarak görüntülenebilir.

## 🏭 Fabrika Ürün Ekleme

<img width="1305" height="570" alt="image" src="https://github.com/user-attachments/assets/618595ee-411f-455c-8e29-d1c3efad72be" />

➕ Bu sayfa üzerinden fabrikaya yeni ürün ekleme işlemi yapılabilir.

## 📦 Depoya Ürün Ekleme

<img width="1563" height="584" alt="image" src="https://github.com/user-attachments/assets/b56697c4-8c86-4673-80b8-0e70ea212b01" />

➕ Bu sayfa üzerinden depolara ürün ekleme işlemi yapılabilir.  

📋 Ürün eklenirken **ürün seçimi, miktar bilgisi ve ilgili depo** seçilerek ürün depo stoklarına eklenir.

## 👤 Personel Kayıt Sayfası

<img width="1053" height="830" alt="image" src="https://github.com/user-attachments/assets/9bb6ccfa-2322-4634-99bf-c6e7426887a4" />

📝 Admin kullanıcıları bu sayfa üzerinden hem **personel kaydı** hem de **admin kaydı** oluşturabilir.

🔒 Personel girişi yapıldığında bu yönetim alanları **gizli olacak şekilde tasarlanmıştır**.





<h1> Kütüphane Yönetim Sistemi </h1>
<h3> AnaSayfa </h3>

- Bu web uygulamasında verileri göstermek için Jtable UI kütüphanesi kullanılmıştır. Bu kütüphane ajax ve jquery aracılığı ile web serverımızdan dataları paginated şekilde göstermemize yardımcı olur. 
- View Details butonu tıklanılan kitabın id'sine göre detay sayfasına yönlendirir
- Ana Sayfa
- ![image](https://github.com/user-attachments/assets/e12e2d20-0e60-4e40-85ea-cf8638bbde44)
- Detay Sayfası
- ![image](https://github.com/user-attachments/assets/eb9436f7-176b-4dc4-a992-d211cbc8a4cf)

<h3>Identity sistemi</h3>
- Kullanıcı logout olduğunda veya ilk defa giriş yaptığında login navbarı ve login sayfası bu şekilde görünür.

- ![image](https://github.com/user-attachments/assets/55a3a25c-b662-45e0-84fa-9e3370cae81d)
- Kullanıcı bilgilerini başarıyla girdikten sonra eğer admin değilse Admin butonu olmadan admin ise navbarın sağında admin butonu olacak şekilde görünür. 
- Eğer kullanıcı izinsiz olduğu bir linke tıklarsa login sayfasına yönlendirir veya hata sayfası karşılar.

<h3> Admin Sayfası </h3>
- Admin sayfası users ve roles tabı içeren 2 sayfadan oluşmaktadır. Users tablosunda da bir jtable aracılığlya sistemde var olan kullanıcılar listelenmiştir. Burada add new record butonu ve listenin yanındaki delete ve edit butonlarıyla datalara crud işlemi uygulayabiliyoruz. Seçilen kullanıcılara rol ekleme silme işlemi için de alta başka bir tablo oluşturulmaktadır.

- ![image](https://github.com/user-attachments/assets/34ee8ba2-f792-46bd-aea1-1fd411d16b86)

<h3> Proje Mimarisi </h3>
- Projede MVC yapısı kullanılmıştır. .Net Identity aracılığıyla kullanıcı ve rol işlemlerimizi repository katmanında gerçekleştirmekteyiz. Servis katmanında update ve delete işlemlerini kaydetmek için UnitOfWork sınıfı kullanılmıştır. Jtable'dan gelen CUD için gerekli datalar record yapısındaki dto'lar ile servislere verilmiştir. Crud işlemleri sonucu controllerdan dönen datalar Jtable tablolar için json yapısındadır.

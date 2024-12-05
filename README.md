<p1> Bu ödevde her bölüm farklı dosyalarda kodlanmıştır.  </p1>
<h3> 1. Bölüm SOLID Principles</h3>

- Solid prensiplerini anlayarak ve uyulmaz ise ne tür bir kod yapısıyla karşılaşabileceğimizi ölçmeyi sağlar.
- 1 - Single Responsibility Principle
  - Bu prensipte amacımız bir sınıfa kendi alanı dışında başka yük bindirmemektir. Örnek kodda öncelikle ProductService dosyası oluşturulmuştur. Bu dosya daha önce oluşturduğumuz DataRepository ve AdminSmsEmailRepository'yi çağırır.
  - Bu sınıfın içinde add product metodu bulunur. Bu metod verilen product nesnesinin validasyonlarını kendi içinde öncelikle kontrol eder. Daha sonra productu kaydetme işlemini gerçekleştirir. En sonunda ise admin kullanıcılarına email gönderen servisi çağırır
  - 

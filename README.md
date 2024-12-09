<p1> Bu ödevde her bölüm farklı dosyalarda kodlanmıştır.  </p1>
<h3> 1. Bölüm SOLID Principles</h3>

- Solid prensiplerini anlayarak ve uyulmaz ise ne tür bir kod yapısıyla karşılaşabileceğimizi ölçmeyi sağlar.
- Bu bölümün kodları SOLID Principles dosyası içinde yer alır. Her bir principle hem uygulananan hem de uygulanmayan örneklendirmeler bulundurur. 
- 1 - Single Responsibility Principle
  - Bu prensipte amacımız bir sınıfa kendi alanı dışında başka yük bindirmemektir. Örnek kodda öncelikle ProductService dosyası oluşturulmuştur. Bu prensipe uymadığımız Without SRP klasöründeki koddaki addProduct metodunda product'u kaydetme işleminin yanı sıra validasyon kodları ve ekleme tamamlandıktan sonra yapılacak kodlar tek bir metodda toplanmıştır.
  - With SRP klasöründe ise yardımcı validasyon ve notifier klasları oluşturulmuştur. Bu şekilde kodda metoddan önce ve sonra sadece yardımcı sınıflar çağrılarak SRP'ye uygun yapı oluşturulmuştur.
- 2 - Open Closed Principle
  - Burada ise Open Closed Prensibi uygulanmayan classta her bir product tipi için belirlenen mesaj productın tipine göre if yapısı içinde belirlenerek uygun mesaj dönmektedir.
  - With OCP classında ise class'ın instance'ına bakmak yerine her instance bir üst classındaki metodu override ederek uygun mesajı döner. Bu şekilde metodda verilen product classı hangi instance olmaksızın içindeki metod yazdırılarak uygun dönüş yapılır.
- 3 - Liskovs Substition Principle
  - Burada liskovun prensibine uymayan kodda göre öncelikle her alt sınıfın üst sınıftaki metodu implement edemediği bir class oluşturduk. Eğer metodu çağrılan class'ın instancesi o class ise metodu uygulamak yerine exception fırlatacaktır.
  - Liskovun prensibine uyan kodda ise metod classa interface özelliği ile eklenmiştir. Bu şekilde metodu uygulamayacak olan classlar bu interfaceyi implement etmez. Kodda ise verilen class bu interfaceyi implement ediyorsa istenen metod uygulanır.
- 4 - Interface Segretation
  - Bu prensibin uygulanmadığı kodda ise tüm metodları contextlerine göre ayırmak yerine hepsini tek interface ve classta implement ettik. Bu da gereğinden fazla kalabalık bir class ve interface yapısına sebep oldu.
  - Bu prensibin uygulandığı kodda ise interfaceler ve onları implement eden classlar cqrs yapısına uygun şekilde ayrılmıştır. Bu şekilde daha okunur ve düzenli bir yapı elde edilmiştir
- 5 - Dependency Inversion Principle
  - Bu prensibin uygulanmadığı kodda classın ihtiyaç duyduğu bağımlılıklar bir interface olmadan classın içinde newlenerek eklenmiştir. Bu yöntem sonucunda eklenen dependencylerdeki herhangi bir değişiklik kodun da değişmesine sebep olacaktır.
  - Bu prensibin uygulandığı kodda ise classın ihtiyaç duyduğu bağımlılıklar interfaceler aracılığı ile injekte edilmiştir. Böylece interfaceler değişmediği sürece kod değişikliklerden ilgilenmez. Ayrıca burada kod bağımlılıkları constructerında injecte ederek kodun nereden ne şekilde oluşturulduğu ile de ilgilenmek zorunda kalmaz.

<h3> 2. Bölüm Asenkron Programlama</h3>

- <p> Bu bölümde asenkron programlama ile ilgili örneklere yer verilmiştir. </p>
- 1 - Asekron kod yazımı - Uzun süren bir taskın senkron gerçekleşmesi
  - Async Methods klasöründe 2 örnek klasör verilmiştir. Burada amaç tüm kullanıcılara sms gönderilmesidir. Bu işlem sırasında eğer sms gönderme işlemi fail olursa (%10 ihtimal verilmiştir) 2 sn sonra tekrar denenmesi için bir faultback sistemi kurulmuştur. Bu sistem senkron olarak uygulandığında her fault olduğunda kod 2 sn bekleyeceğinden diğer smslerin işlenmesi engellenmiştir.
  - WithAsync klasöründe ise bu işlem Parallel.Foreach metodu ile async olarak gerçekleştirecektir. Bu şekilde herhangi bir sms fail olduğunda beklemek threadi bloklamayacaktır. 
  - Task Examples sınıfında Task sınıfına ait statik metodların örneği verilmiştir.
- 2 - Async await kullanımı
  - Async Await Usage sınıfında bir dizi statik metod oluşturulmuştur. Proccess order metodu gelen sipariş requestini oluşturulan statik listeyi kontrol ederek oluşturur. Bu oluşturma işlemi sırasında stock kontrolü , kullanıcı balance kontrolü gibi işlemler için metodlar oluşturulmuştur ve bu metodlara belirli bir oluşturma zamanı statik olarak atanmıştır. Amaç bu oluşturma işlemi sırasında bir işlemin diğer işlemin bitmesini beklemeden eş zamanlı başlatmaktır. Ayrıca her metodda olası bir hata için try catch yapısı oluşturulup eğer bir exception çıkarsa ExceptionHandler sınıfındaki handle exception metodunda hata elden geçirilmiştir.

<h3> 3. Bölüm Api Geliştirme En iyi Uygulamaları</h3>

- <p> Bu bölümde api projesi üzerinden bir kütüphane api kurulmuştur.</p>
- 1 - Api EndPoint isimlendirme
  - Api projesindeki LibraryController içindeki her method crud opersyonları uygulayabilecek şekilde api endpointleri uygun http metodlarına göre ve yapılan işleme göre adlandırılmıştır.
- 2 - Pagination
  - Pagination işlemi için birden fazla değer dönen endpointler için dönen datayı sınırlandırmak için uygun pagination filtre parametreleri verilmiştir. Bu parametrelere göre tüm datayı dönmek yerine datanın bellirli bir kısmı repositoryden döndürülmüştür.
- 3 - Hata Yönetimi
  - Apide uygun hata yönetimi oluşturmak için bir serviceprovider interfacesini implement eden ExceptionHandlerInjectionModule sınıfı oluşturulmuştur. Bu sınıfa program.cs'te tanımlayacağımız exception handlerlar tanımlanmıştır. Exception handler gelen bir Exceptionı eşleştirdiği handler ile uygun hata dönüşü yapmayı sağlar.
- 4 - Önbellekleme
  - Önbellekleme için Redis cache kullanılmıştır. Öncellikle program.cs dostyasında ve appsettingste belirli configurasyonlar yapılarak projeye eklemiştir. Daha sonra Controller içindeki Books metodunda istek öncelikle repositorye gider. Repository gelen requestin cache durumuna uygun olup olmadığını kontrol eder. ( bu durumda eğer gelen request default olarak ilk 10 datayı istemişse o cache edilecek şekilde configure edilmiştir). Eğer cache durumuna uygunsa ( yüklü bir data istenmiyorsa) cache repositorye istek yönlendirilip istenilen data cachete olup olmadığı kontrol edilir. Eğer data cachede ise ugun dönüş yapılır değilse cacheye kaydedilir.
  

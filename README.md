# AspNetCoreWebApiPaket
N Katmanlı Yapı İle Asp.NET Core 3.0
<br><br>
Asp Net Core Web Api Paketinde N Katmanlı yapı ile Category ve Note clasları ve bunlara ilişkin repository'ler var. Ayrıca Identity ile kullanıcı kayıt ve login işlemi ve veri erişim sınıflarında ilişkiler var.
<br><br>
  Visual Studio ile açtıktan sonra, veritabanını hazırlamak için migrations işlemleri yapılmalıdır.
<br><br>
Solution'da Paket.MyNotes.WebapiServis klasörü powershell ile açıldıktan sonra powershell'de aşağıdaki komut çalıştırılarak ana dbcontex'imiz için migrations oluşturulur.<br><br>
  ```dotnet ef migrations add firs -c MyNotesDbContext```
<br><br>
Daha sonra oluşturulan migrations'ı veritabanına yansıtmak için <br><br>
  ```dotnet ef database update -c MyNotesDbContext```
<br>
çalıştırılır.
<br><br>
Aynı işlemler Identity için de gerçekleştirilir.
<br>
  ```
  dotnet ef migrations add firstIdentity -c AppIdentityDbContext
  dotnet ef database update -c AppIdentityDbContext
  ```
<br>
Böylelikle veritabanı ve gerekli tablolarımız oluşmuş olur.
<br><br>
Projeyi çalıştırdığınızda SeedData ve SeedIdentityData sınıfları çalışacak ve ilk veriler veritabanına kaydolacaktır.
<br>
Siz bu sınıflardaki veriyi kendinize göre düzenlemeyi unutmayınız.

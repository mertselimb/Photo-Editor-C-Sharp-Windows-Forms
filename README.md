
 GÖRÜNTÜ İŞLEME EDİTÖRÜ
Bilgisayar Mühendisliği Bölümü
Kocaeli Üniversitesi




 
Özet
Bizden histogram, tersleme,sağa-sola aynalama işlemi,döndürme,ölçeklendirme,tekrar açma, gri tonlama ve renk kanalları fonksiyonlarını kullanan bir görüntü işleme projesi istendi. Projeyi geliştirirken istenildiği üzere C# dilini ve Visual Studio geliştirme ortamını kullandık fonksiyonları nasıl kullanacağımızı, ekleyeceğimiz kütüphaneleri internet üzerinden araştırıp kullanıma dâhil ettik. Projemizin amacı belirtilen fonksiyonları başarı ile gerçekleştirebilen özgün bir görüntü editörü yapmaktır. Bunu özgün şekilde kodlayarak ve kişisel bakış açısı katarak kurallar ve sınırlar dâhilinde yapmayı amaçladık. Kaynaklarını raporumuzda belirteceğimiz sitelerden veri toplama işlemini gerçekleştirdikten sonra istenilen projenin algoritmasını kurduk. Kaynaklardan elde ettiğimiz verileri işleyerek, projemize dâhil etmeye başlayarak ilerledik. Adım adım istenilen fonksiyonları gerçekledik ve kontrol ettik. Sonuç olarak başarılı bir proje elde ettik. 
1.	Giriş
Projede yapmak istediğimiz histogram,tersleme,sağa-sola aynalama işlemi,döndürme,ölçeklendirme,tekrar açma, gri tonlama ve renk kanalları fonksiyonlarını çalıştıran görüntü işleme editörüdür. Görüntü işleme kısaca: isim (Almanca: Bildbearbeitung) ölçülmüş veya kaydedilmiş olan elektronik (dijital)görüntü verilerini, elektronik ortamda (bilgisayar ve yazılımlar yardımı ile) amaca uygun şekilde değiştirmeye yönelik yapılan bilgisayar çalışması.
Bizim projede yapmaya çalıştığımız işler üzerine daha önceden Microsoft , Apple , Samsung gibi dev teknoloji firmaları dahil olmak üzere birçok firmanın yanı sıra kamu alanında da Tübitak örnek olmak üzere çeşitli kurumların çalışmaları bulunmaktadır. Telefonlarda sıklıkla photoshop amaçlı, mobil uygulama olarak kullanılan görüntü işleme teknolojisi yaygın ve revaçta bir pozisyonda bulunmaktadır.

Projemizin amacı istenilen fonksiyonları başarı ile gerçeklemek ve görüntüleri sorunsuz şekilde işlemektir. Programa girilen verinin(görsel içeriklerin) doğru ve sorunsuz şekilde fonksiyonlar tarafından işlenmesini bekliyoruz. Denemelerimiz ve çalışmalarımız sonucunda tamamladığımız programımız sorunsuz şekilde istenilen fonksiyonları çalıştırmaktadır. Görüntüyü işlemektedir.

2.	Temel Bilgiler
Projeyi gerçeklerken yararlandığımız teknolojiler Visual Studio ve C# dilidir. Viusal Studio ya da tam adıyla Microsoft Visual Studio; Windows masaüstü, modern – eski ve bilinen adıyla metro-ara yüz(Windows 8/8.1/Windows 10 ve Windows Phone’lar için uygulama geliştirmemize yarayan bir yazılım ve platformdur. Edinmesi oldukça kolaydır. Express, Professional ve Ultimate olarak sürümleri mevcuttur. Express ücretsizdir. Express, diğer sürümlerinden farklı olarak Windows modern ara yüz, Windows Phone ve Windows masaüstü geliştirme araçlarını ayrı ayrı sunar. Yani kullanacağımız ortama göre ya mobil ya da masaüstü sürümünü edinmemiz gerekir. Visual Studio en basit tanımı ile program yazma programıdır. Tamamen kod ile programlarınızı yazabileceğiniz gibi, kodu kısarak görsel bir biçimde de program ara yüzü oluşturabilirsiniz. Visual Studio içerisinde Visual Basic NET, Visual C# ve Visual C++ gibi görsel destek sağlayan ve bizim projemize de katkısı olan dilleri barındırır. Bu sayede kısa sürede daha güzel ara yüzlere sahip olan programlar oluşturmamıza olanak sağlar. 
Visual Studio, Microsoft tarafından üretilen ve konsollar, grafik kullanıcı ara yüzleri, Windows formları, Web servisleri ya da Web uygulamaları oluşturmak için kullanılan bir IDE’dir. Visual Studio programı içerisinde yalnızca Microsoft Windows tarafından desteklenen yerel kodlar kullanılmaktadır.
Visual Studio son derece fonksiyonel ve şık ara yüz tasarımına sahiptir. Bu fonksiyonel arayüzle birlikte Visual Studio yazılımcıların yükünü hafifletecek bir kod editörü, debugger, GUI tasarlama aracı, veri tabanı şema tasarım aracı ve öncül revizyon kontrol sistemlerini sunuyor. Visual Studio yazılımın ticari amaçla kullanılan ticari program şeklinin yanı sıra topluluk bazlı olarak geliştirilen ücretsiz sürümü de bulunmaktadır.
Visual Studio her ne kadar bir geliştirme ortamı olsa dahi Eclipse gibi bu ortam içerisinde birçok programlama dilini kullanamıyor, sadece Visual Studio tarafından desteklenen diller üzerinden çalışabiliyorsunuz. Visual Studio yazılımının desteklediği programlama dilleriyse şunlardır;
•	C
•	C++
•	C#
•	Visual Basic .NET
•	F#
•	Fossil
•	M
•	Python
•	HTML/XHTML/CSS
•	JavaScript

Diğer bir aracımız olan C# dilinden bahsedecek olursak; C#, yazılım sektörü içerisinde en sık kullanılan iki yazılım dili olan C ve C++ etkileşimi ile türetilmiştir. Ayrıca C#, ortak platformlarda taşınabilir bir ( portable language ) programlama  dili olan Java ile pek çok açıdan benzerlik taşımaktadır . En büyük özelliği ise .Net Framework platformu için hazırlanmış tamamen nesne yönelimli bir yazılım dilidir. Yani nesneler önceden sınıflar halinde yazılıdır. Programcıya sadece o nesneyi sürüklemek ve sonrasında nesneyi amaca uygun çalıştıracak kod satırlarını yazmak kalır.
Microsoft tarafından geliştirilen C#, C++ ve Visual Basic dillerinde yer alan tutarsızlıkları kaldırmak için geliştirilmiş bir dil olmasına rağmen kısa süre içerisinde nesne yönelimli dillerin içinde en gelişmiş programlama dillerinden biri olmayı başarmıştır.
Ayrıca gelişmiş derleyicisi ( debugger ) ile hata olasılığını ortadan kaldırmaktadır. Yazılan program çalıştırıldıktan sonra derleyici tarafından algılanan Sınıf (Class) ve söz dizimi ( syntax ) hataları yazılımcıya ayrı bir ekranda ayrıntısı ile gösterilir ve yazılımcı bu hata penceresinden hataları tespit ederek kolayca düzeltebilir.
Bütün bilgisayar dilleri birbirleri ile ilişkilidir. Programlama dillerinde öncelikle C programlama dili ortaya çıkmıştır. C dili 1960’lı yıllarda yapısal programlama (structured programming) ile ortaya çıkmıştır. Yapısal programlama, düzgün kontrol ifadelerinin yer aldığı, bu ifadelerin hiyerarşik bir şekilde birbirini izlemesi şeklindeki bir programlama türüdür. C dili çok büyük projeleri yönetme açısından yetersiz kalan bir dildir ve bu problem yazılımcıları yeni diller aramaya yöneltmiştir.
Bu problemi çözmek amacı ile nesne yönelimli programlama(OOP-object orinted programming)adı verilen yeni bir programlama yöntemi ortaya çıktı. Nesne yönelimli programlamada büyük projelerin yönetimine olanak sağlayan yapılar bulunmaktaydı. C dili bu tür programlamayı desteklemiyordu bu yüzden C++ dili Bell laboratuarında geliştirildi ve C dilinin bütün özelliklerini içermektedir.
1991 yılında Sun Microsystems tarafından Java dili geliştirildi. Java büyük ölçüde C++ dilinden yapısal anlamda yararlanmıştır. İnternetin kullanımının yaygınlaşması ile birlikte yazılan programların dağıtılması gündeme gelmiş Java geliştiricileri kodlarının her bilgisayarda çalışması için Java Sanal Makinesi(JVM-java virtual machine) geliştirmişlerdi. Java kodları derlendikten sonra JVM aracılığı ile bilgisayarlarda çalışmaktaydı; Java sistemindeki JVM ile çalıştırılabilmesine rağmen Windows sistemler ile tam uyumlu değildi. Java dilinde diller arası uyumun olmaması yeni bir dilin geliştirilmesi için gerekçe oluşturmaktaydı. Dilin uyumlu olması demek bir dilde yazılan bir kodun başka bir dil ile aynı program içerisinde çalıştırılabilmesi demektir. Bütün bu problemlerin çözümü için Microsoft, 1990’lı yılların sonlarına doğru C# dilini geliştirdi. C# kodları derlenirken; Kodlar MSIL (Microsoft Intermediate Language) yapısına çevirilir. Bu kod işlemci tarafından tanınan bir kod yapısı değildir ve direk olarak çalıştırılamaz. Kodu çalıştırılabilir hale getiren CLR(Common Language Runtime) yapısıdır.Yazılan kodlar .NET framework olan bütün bilgisayarlarda çalışır durumdadır ayrıca .NET ortamında bir projeyi iki veya daha fazla dil ile ortak yazabilirsiniz.


Histogram: sayısal bir resim içerisinde her renk değerinden kaç adet olduğunu gösteren grafiktir. Bu grafiğe bakılarak resmin parlaklık durumu ya da tonları hakkında bilgi sahibi olunabilir.
Histogram Eşitleme: Histogram eşitleme ile belirli bir ton etrafında toplanan histogram eğrisi  (0-255) tonları arasına düzgün bir şekilde dağıtılır böylece resmin gri ton dağılımının homojen olarak yapılandırılması sağlanır. Histogram eşitleme işleminde, resmin kümülatif gri seviye dağılım skalası üzerinde normal dağılım uygulanmaktır. Bu yeniden dağılım, gri seviye dağılımında dengeleme sağlamaktadır.
Piksel(Pixel): Picture element sözcüklerinin birleştirilmesiyle oluşturulmuştur, görüntünün birim elemanını ifade eder.
Tersleme: Bir diğer adı negatiflemedir. Siyah arka plana sahip görüntülerin beyaz ve gri tonlarının belirginleşmesini sağlar. 8 bitlik görüntülerde piksel değerinin 255’ten çıkarılmasıyla tersleme işlemi gerçekleşmiş olur.
Görüntü İşlemenin Tarihçesi
 Yaklaşık yedi yüz milyon yıl önce yaşamış ilkel canlılarda göz benzeri organların evrimi ile görüntüleme başlamıştır. Bu ilke organlar görüş alanındaki üç boyutlu objelerden yansıyan ışığı iki boyutlu ilkel göz yüzeyinin üzerine iz düşürerek görüş alanının basitleştirilmiş bir modelini oluşturmaya yaramıştır.  Kalıcılık değeri yüksek olan ilk görüntüleme mağara resimleri ile başlamıştır. Tarih boyunca ilerleyen resim teknikleri günümüze kadar gelişmeye devam etse de, mağara duvarlarından orta çağ ressamlarının tuvallerine, modern duvar resimlerinden gelişmiş dijital animasyonlara kadar sayısız teknikte değişmeyen tek unsur uzayın insan gözü ve beyni ile yorumlanması olmuştur.  Fotoğraf makinesinin icadı ile insan yorumu; ışık, odak ve açı ile ayarları sınırlandırılmıştır. Fotoğraf makinesinin atası, karanlık kutu (camera obscura) adı verilen ve yüzeylerinden birinde iğne deliği bulunan bir kutudur.
Aristo da yine aynı dönemlerde güneş tutulmasının yaprakların arasından süzülmesini tasvir eder.  Günümüze kadar dayanacak kalitede fotoğraf çekebilen ilk fotoğraf makinesi Joseph Nicéphore Niépce tarafından 1825 yılında yapılmıştır.  İlk deneysel renkli fotoğraf ise James Clerk Maxwell tarafından 1861’de çekilmiştir  Dijital olarak ışık algılama fikri 1961 yılında bir uzay araştırma konferansında önerilmiş, önerilen mantıktaki bir ışık algılama paneli 1968’de üretilmiştir.  İlk dijital fotoğraf makinesi ise 1975 yılında Steven Sasson adındaki bir mühendis tarafından Kodak bünyesinde tasarlanmıştır. Ağırlığı 3,6 kg olan ve 23 saniyede 0.01 mega piksel çözünürlüğünde renksiz fotoğraf çekebilen bu kamerada uzay araştırmaları için 1973 yılında üretilmiş bir Charge Coupled Device (CCD) algılayıcı kullanılmıştır.
İlk hareketli görüntü kaydı 1880’lerin sonunda yapılmıştır. Hareketli bir görüntünün insanlar tarafından kesintisizmiş gibi algılanabilmesi için saniyede 20 kareden fazla çerçeve gerekse de pratik olarak daha az sayıda çerçeve içeren video sistemleri de mevcuttur.  Günümüzde geliştirilmekte olan en son teknoloji üç boyutlu görüntülemedir. Temel olarak sağ ve sol gözün hizasına yerleştirilmiş iki ayrı kamera tarafından aynı anda çekilen iki görüntü, sağ ve sol göz aynı filtrelerle yansıtılarak bir göz yanılgısı yaratılır. 1950’lerde deneysel çekimleri yapılan üç boyutlu filmler; teçhizat ve montaj masrafları, kırmızı/yeşil/mavi camlı gözlüklerdeki renk derinliği kaybı, vb. nedenlerle popüler olamamıştır.  Günümüzde polarize, dijital perdeleme vb. teknolojiler kullanan gözlüklü üç boyutlu görüntüleme sisteminin yanı sıra dar açıdan gözlüksüz izlenebilen üç boyutlu ekranların da üretimine başlanmıştır.
Görüntü İşlemede Temel Kavramlar

Piksel: Picture element sözcüklerinin birleştirilmesiyle oluşmuştur. Görüntünün birim elemanını ifade eder.  Parlaklık x ve y koordinatlarındaki bir pikselin parlaklık değerini gösterir.  Ayrıklaştırma: Analog görüntünün dijital sistemde ifade edilebilmesi için önce uzaysal boyutlarda sonlu sayıda ayrık parçaya bölünmesi (örnekleme, sampling), sonra da her bir parçadaki analog parlaklık değerinin belli sayıda ayrık dijital seviyelerden biri ile ifade edilmesi (kuantalama, quantizing) gerekir.  Çözünürlük: İnç ya da cm başına düşen piksel sayısıdır.(1 inç =2.54 cm). Görüntünün kaç piksele bölündüğünü, yani kaç pikselle temsil edildiğini gösterir. Çözünürlük ne kadar yüksekse görüntü o kadar yüksek frekansta örneklenmiş olur ve görüntüdeki ayrıntılar o kadar belirginleşir.  Uzaysal Frekanslar (Spatial Frequencies): Uzaysal boyutlarda belli bir mesafede parlaklık değerinin değişim sıklığını ifade ederler.  Giriş Görüntüsü: İki boyutlu, MxN uzunluktaki bir matris olarak düşünülür ve sol üst köşedeki piksel değeri (1,1) başlangıç noktası olarak numaralandırılır.
Görüntü İşlemenin Geleceği Ve Sonuçlar 

Günümüzde görüntü işleme ile ilgili teknolojiler hızla gelişen ve dünya standartlarını önünde sürükleyen sistemlerin gelişmesini sağlamıştır. Gelecekte de hız kesecek gibi görünmeyen bu gelişimde mühendislerin, akademisyenlerin, destek kuruluşlarının ve şirket yöneticilerinin konuya önem verip tasarımı eğitim ve yatırım çalışmalarına hız vermeleri, gelişmiş ülkelerle aynı seviyeye ulaşarak yeni ufuklarda söz sahibi olmamızı sağlayacak önemli bir adımdır. Yeterli eğitim ve yatırım ile 10 yıl öncesinin bilimkurgu teknolojisini gerçeğe dönüştürmek tahmin ettiğimizden çok daha yakın.

3.	Proje İçeriği
Çalışmamıza gerekli kütüphaneleri include ederek başladık. Piksel verileri tarafından tanımlanan görüntüleri ile çalışmak için kullanılan bitmap nesnesini tanımladık. Bmp boş mu diye kontrol ettiriyoruz. Kullanıcımızdan bir dosyayı(içeriği) browse etmesini istiyoruz işlemin başarılı olup olmadığını, girilen değerin null olup olmadığını kontrol ediyoruz.
Doğru atama işlemini sağlamak için elle dispose yöntemini çağırmak yerine OpenFileDialog fonksiyonunu kullanıyoruz ve veri girişini sağlıyoruz.
Daha sonra histogram region’u açıyoruz. Ardından histogramları kırmızı, yeşil ve mavi olarak tanımlıyoruz. Bunu da EventArgs ile sender – parametre ilişkisi kurarak meydana gelen olaya ait parametreyi koşulda kontrol ediyoruz.
Sonrasında histogramları visible ile görünür hale getiriyoruz.
Yeniden tıklamaya karşı da boşaltıyoruz. 
Bir sonraki adımda histogramı array’e alıyoruz. 
Draw(); ile de çizdiriyoruz.
Sıra pikselleri diziye atamaya geldi. İç içe iki döngü ile pikselleri bitmapMain.GetPixel(i,j); fonksiyonu ile diziye alıyoruz.
Üç adet  tanımladığımız için (ImageRed,ImageGreen,ImageBlue) şeklinde üç kez pikselleri diziye alıyoruz.
Sonrasında Draw işlemi için üç adet ayrı döngü kurup charta çizdiriyoruz. Bu bölgeyi sonlandırıp kullanıcımızın başlangıç ile farkı görebilmesi için yardımcı bir blok oluşturuyoruz.
btnCloseReOpen_Click(object sender, EventArgs e) özel fonksiyonu ile içerisine koşul oluşturup true ise döndür işlemi uyguluyoruz. Başlangıçtan farkı görmek için değişimi kapatıyoruz.
Private void save() ile kaynağa her fonksiyon öncesi verileri geri atıyoruz. Daha sonrasında eski veriyi alup kaynağa kayıt ediyoruz. Display’e yüklüyoruz. En başa verileri kaydederek geri dönüş sağlıyoruz. Eski veriyi kaynağa kayıt ediyoruz. Tekrar display’e yüklüyoruz.
Bir önceki adıma geçiş için ptbDisplay.Image = back; komutunu yerleştirdik.
Bu kodlar ile using(SaveFileDialog dlgSave = new SaveFileDialog() , save dialog açıp *.bmp olarak kayıt ediyoruz.
Sonraki adımda bitmapMain.Save(dlgSaveFileName); ile bütünleşik bir bölüm ekleyerek projemizi dışa aktarıyoruz. Ve bu bölgeyi de sonlandırıyoruz. 
Doksan derecelik döndürme işlemi yani rotate etmek için RotateImage(bitmapMain,-90)
ptbDisplay.Image = bitmapMain; kodlarını kullanıyoruz. Aynı işemi +90 derece için de uyguluyoruz. Ve kayıt alıyoruz.
Public Bitmap transpozeImage komutu ile matris halinde transpoze işlemi gerçekleştiriyoruz. Bunu da iç içe iki adet döngü ile gerçekliyoruz. Ardından sütunları tersleme işlemini gerçekleştiriyoruz bunu da yine iç içe iki adet döngü ile yapıyoruz. Sonucunda matris halinde sütunların yerlerini değiştiriyoruz. 
Bir sonraki adımda  benzer şekilde ve aynı mantıkta, matris halinde satırların yerini değiştiriyoruz. Bunu da  doksan derecelik açının + ve – olarak koşul ile kontrol ettiriyoruz. Gerekli sıraya göre matris fonksiyonlarını çağırıyoryuz.
Bölümü sonlandırıyoruz. Ardından Negative işlemine geçiyoruz. Hız için lockbits kullandık. Program içerisindeki kodunu gösterecek olursak : BitmapData mainData = bitmapMain.LockBits(new Rectangle(0,0,width,height)); şeklindedir.
Daha sonrasında byte[] array boyutunu hesapladık ve tüm pikselleri bulmak için yükseklik*genişlik dedik.
Marshall kopyamalası kullandık. Örnek kodu Marshal.Copy(mainData.Scan0,buffer,0,arrayLength); şeklindedir ve sonrasında ram’i temizledik.
Rgba kanalları tanımladık. İnnt rgba = 3; şeklinde ve int cChannels = 3; sonuna döngü ekledik for(int y = 0; y<h;y++)
Tüm piksellere bakan bir döngü kurduk. İç içe beş adet for içeren bir döngü.
Array kullandığımız için konumu şimdi örnekleyeceğimiz kodu kullanarak buluyoruz.
Current = y*.mainData.Stride + x*4;
Ve bir döngü oluşturup 255’ten tüm verileri çıkartıyoruz.
Ardından alpha verisini elde ediyoruz. Result[current + 3] = 255; şeklinde.
Son ürüne ulaşıyoruz. Ve tekrar kopyalamdaki hız için lockbits kullanıp Marshall kopyalaması yaptık. Ram’i temizledik outputImage.UnlockBits(outputData);
bitmapMain = outputImagine; şeklinde.
Sonrasında negativini almak için fonksiyon oluşturuyoruz. 
Rectangle ile verileri aldık ve hızlı olması için yine lockbits kullandık. Daha sonrasında ilk satırı tarıyoruz. BmpData.Scan0 ile gerçekledik.
Rgb değerlerinin depolandığı bir dizi oluşturuyoruz. Ve sonrasında yükseklik ve genişlik alıyoruz. Ardından rgbleri matrise atmak için bir matris oluşturuyoruz. Rgb değerlerini array’e kopyalıyoruz kilitli olduğu için Marshall kopyalaması kullandık yine. Color matrisimize göre pikselleri yerleştirdik. Color matrix set ile yapılmıştı fakat yasak olduğu için farklı bir formata dönüştürdük. Byte gray = (byte).(rgbValues[i]*.21 + rgbValues[i+1]*.71 + rgbValues[i+2]*.071);
rgbValues[i] = rgbValues[i+2] = gray; şeklinde format değişimi yapıldı. Ardından Marshall copy ile hızlı olması amaçlanarak tekrar kopyalandı. Kanallar belirlendi red,green ve blue olarak.
Üç adet bitmap tanımladık kırmızı,yeşil ve mavi için. Ardından piksel verilerini aldık. İçinden rgb(kırmızı,yeşil ve mavi)’ yi ayırdık. Koşul ile kontrol ettirerek kırmızı ise ona göre yazdık. Yeşil ise yeşile göre son olarak da mavi ise mavi olarak yazdık. Örnek kaba kodu ggbmp.SetPixel(x,y,Color.FromArgb(a,0,0,b));  şeklindedir.
Sonuçta if koşul deyimi ile color eğer red ise bitmapMain rbmp; else if koşulu ile green ve blue için aynı işlemi kontrol ettirdik. Gerekli kanala gerekli işlemi yaptırdık. Ve bölümü sonlandırdık. ( End region).
Ardından resmin aynalanmış hali için kayıt işlemine geçiyoruz. Programımızda mirrorImg olarak tanımladık. Bitmap ile yeni yükseklik ve genişlik değerleri olan new bitmap tanımladık. Ardından bitmap mirrored için de yeni bir bitmap oluşturduk. Bu da yükseklik ve genişlik değerlerine sahip. Sonrasında iki adet iç içe döngü kullandık. Piksel verisini aldık  GetPixel yardımcı fonksiyonu ile. Son olarak aynadaki veriyi yerine yazma işlemimiz kaldı bu adımda onun için de mirrored.SetPixel komutu ile (solx,y,p); şeklinde tanımlama yaparak yerine yazdık. 
bitmapMain = mirrorImg; ile aynalanmış veriyi kaynağa yazdık. ptbDisplay.Image = bitmapMain; ile veriyi kullanıcıya sunduk.
Bir sonraki aşamamız aynalanmış resim için kayıt işlemidir. Bunun için de Bitmap mirrored = new bitmap(genişlik,yükseklik) şeklinde bir tanımlama ile başladık. Sonrasında iki adet iç içe döngü ile arrayimizin içini doldurduk. Piksel verisini Get.Pixel komutu ile aldık. Aynadaki yerine yazdık. Adımı takip ederek veriyi ana kaynağa yazdık ve kullanıcıya sunduk. İnt sourceWidth ve sourceHeight ile yükseklik ve genişliği inceledik. Resmin dikey mi yoksa yatay mı olduğuna baktık. Koşul koyarak ona göre düzenleme yaptık. Koşulumuz sourceWidht<sourceHeight şeklindedir. Ona göre düzenleme yaptık. Programlarda genellikle başlangıç değeri null olarak başlanırsa sıkıntı olacağı için sourceX, sourceY destinationX ve destinationY float percent, newPercentWidth ve newPercentHeight değerlerimize sıfır atadık. Oranları aldık yani genişlik oranı/ yükseklik oranı;
Ardından ana oranları nPercent = nPercentH;
destX = System.Convert.ToInt16((newWidth-(sourceWidth*nPercent))/2); komutu ile ayarladık.
Orana göre hedef x belirleniyor.Bir koşul ile oran farklı ise diye kontrol ettiriyoruz. Büyük resimde nereye yerleştireceğimize bakıyoruz yeni resmi. Son ürünü oluşturuyoruz. 
Ardından resmin kaça kaç oranında olduğunu kontrol edip ayarlama yapıyoruz ki resimde boşluk kalmaması için. Arkaplanı da siyah ile dolduruyoruz. Bunu da şu kod kısmı ile gerçekliyoruz: grPhoto.Clear(Color.Black);
Ardından resmi draw ediyoruz yani çizdiriyoruz. grPhoto.DrawImage(bitmapMain, new Rectangle(destx,dest y ,destWidth,destHeigth), şeklinde.
Ardından rami temizliyoruz. Ve bölümü kapatıyoruz. Bitmapmain.Dispose();
bitmapMain = output;
İle resmin boyutunu değiştiriyoruz. Kodları tam olarak eklemedik çünkü programı zaten sunacağız. Olabildiğince kaba kod şeklinde amacını hedefini belirten ve yöntem olarak gördüğümüz kodları burada kullandık. Yararlandığımız fonksiyonları belirtmeye çalıştık. 
4.	Sonuçlar
Çalışmamız ve projemiz istenilen kriterleri karşılamaktadır. İstenilen bütün fonksiyonları ekledik ve kullandık. Çeşitli denemeler ile sınadık. Zorlandığımız kısım ise histogram oldu. Gerekli araştırmayı yaptıktan sonra zorlansak da histogramı da gerçeklemeyi başardık. Sonuç olarak beklenilen görüntü editörünü yaptık ve Kocaeli Üniversitesi Bilgisayar Mühendisliği bölümü yazılım laboratuvarı 1. Projesini tamamladık. Hedeflediğimiz noktaya ulaşmış olduk. 
Görüntü işleme teknolojisini ve yöntemlerini tanıdık ve araştırmış olduk. Gelecekteki yerini irdeledik ve günümüzdeki durumuna dair düşündük. Bu bağlamda projenin bize yazılım bilgisi ve genel bilgi kattığını söyleyebiliriz. Sadece bilgisayar mühendislerinin değil birçok alanda çalışma yapan insanların bu teknolojiyi kullandığını öğrendik. Elimizden geldiğince iyi şekilde öğrenmeye çalıştık. Derecelendirme ve takdir hocalarımızın olacaktır.
5.	Kaynakça
Her bir kaynak aşağıda verildiği gibi numaralandırılmıştır ve rapora eklenmiştir. İntihal olmaması adına kaynaklara özen gösterilmiştir.
[1]  http://kazzkiq.github.io/svg-color-filter/
[2] https://alistapart.com/article/finessing-fecolormatrix
[3] https://github.com/yusufshakeel/CSharp-Project/blob/master/src/MirrorImage/Form1.cs
[4] https://stackoverflow.com/questions/33338900/how-to-mirror-an-image

[5] https://www.wikihow.com/Transpose-a-Matrix

[6] http://csharphelper.com/blog/2015/09/draw-a-simple-histogram-in-c/

[7] http://trompelecode.com/blog/2012/04/how-to-create-an-image-histogram-using-csharp-and-wpf/

[8] http://web.cs.wpi.edu/~emmanuel/courses/cs545/S14/slides/lecture02.pdf

[9] https://web.stanford.edu/class/cs101/image-1-introduction.html
[10] https://epochabuse.com/scale-images/
[11] https://epochabuse.com/csharp-image-negative/

[12] https://epochabuse.com/csharp-grayscale/

[13] https://www.youtube.com/watch?v=Sx0sTWKvkz4
[14] https://github.com/yusufshakeel/CSharp-Project/blob/master/src/RedGreenBlueImage/Form1.cs

[15] https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp

[16] http://www.teknokoliker.com

[17] http://wikipedia.com
[18] https://www.slideshare.net/BetulKesimal/grnt-ileme-72697139
[19] http://matlabgoruntuisleme.blogspot.com.tr/2012/09/basit-goruntu-islemleri-ve-histogram.html
[20] http://www.mshowto.org/c-net-programlama-dili-nedir.html

5.1.	Şekiller
Bu bölümde proje içerisindeki ana hatları görsel olarak ifade edeceğiz.
 
Şekil 1: Histogramların tanımlanması.
 
 
Şekil 2: Piksellerin diziye atanması.
 
Şekil 3:Eski verilerin ana kaynağa kaydı ve display’e yüklenerek geri dönülmesi. 
Şekil 4: Save dialog açılması ve projeyi dışa aktarma işlemi.
 
Şekil 5: 90 derecelik döndürme işlemi.
 
Şekil 6: Matrisin transpoze işlemi.
 
Şekil 7: Gerekli sıraya göre matris fonksiyonlarının çağırılması işlemi.

 
Şekil 7:Kopyalamadaki hız için lockbits kullandık.
 
.
Şekil 8: Marshall kopyalaması yaptık. 
Şekil 9: 3 adet bitmap kırmızı,yeşil ve mavi(rgb)


 .
Şekil 10:GetPixel ile veriyi aldık.
 
Şekil 11: Resmin dikey ya da yatay olmasının incelendiği ve düzenleme yapıldığı  kısım.

 
Şekil 12: Yeni resmin büyük resimde nereye yerleştirileceğine karar verilen aşama. Son ürün ve arka planın siyah olması işlemi.


using MovieApp.Models;

namespace MovieApp.Data
{
    public static class ProductRepository
    {
        private static List<Movie> _movies = null;
        static ProductRepository()
        {
            _movies = new List<Movie>()
            {
            new Movie() { Id = 1,Name="Shazam",Description="A newly fostered young boy in search of his mother instead finds unexpected super powers and soon gains a powerful enemy.",ImageUrl="1.jpg",LongDescription="Shazam! Tanrıların Öfkesi, sihirli kelime olan “SHAZAM”ı söyledikten sonra Süper Kahraman alter egosu Shazam’a dönüşen, genç Billy Batson’un maceralarını konu ediyor. Tanrıların güçlerinin bahşedildiği bu yeni macerada, Billy Batson ve üvey kardeşleri, yetişkin Süper Kahraman alter-egolarına sahip olarak gençlik hayatlarıyla nasıl başa çıkacaklarını öğrenmeye çalışır. Eski tanrılardan oluşan intikam peşindeki bir üçlü, uzun zaman önce kendilerinden çalınan sihri aramak için Dünya'ya geldiğinde, Shazam ve müttefikleri süper güçleri, hayatları ve dünyanın kaderi için zorlu bir savaşın içine girerler.",CategoriesId=new List<int>{1,5,6,7}},
            new Movie() { Id = 2,Name="Amazing Grace",Description="The idealist William Wilberforce (Ioan Gruffudd) maneuvers his way through Parliament, endeavoring to end the British transatlantic slave trade.",ImageUrl="2.jpg",LongDescription="18. yüzyıl İngiltere'sinde geçen film, İngiliz Parlamentosu'nda yasama meclisine seçilen dinci siyasetçi Christian William Wilberforce'un hayatını anlatır. Genç siyasetçini en büyük arzusu yakın bir zaman içerisinde bu yüzyılın en büyük sorunu olan köle ticaretini yok etmektir. Bu hedefindeki en büyük destekçilerden biri şair John Newton'dır. Ancak bu yol fazlasıyla uzun ve zorludur. Çünkü köle ticaretinden büyük gelir elde eden kurumlar vardır ve bu yasanın yürürlüğe girmesine izin vermeye niyetli değillerdir. Wilberforce hayatındaki tüm zorluklara rağmen mücadelesinden vazgeçmeyecektir.Yakın zamanda 'The Chronicles of Narnia: The Voyage of the Dawn Treader' filmini çeken Michael Apted tarafından yönetilen filmin başrollerinde Ioan Gruffudd ve Albert Finney yer alıyor.Fragmanlar",CategoriesId=new List<int>{}},
            new Movie() { Id = 3,Name="High Life",Description="A father and his daughter struggle to survive in deep space where they live in isolation.",ImageUrl="3.jpg",LongDescription="Ömür boyu hapis cezası ile karşı karşıya kalan bir grup suçlunun hikayesini konu ediyor. Onların bu cezayı almamaları için önlerinde tek bir seçenek vardır; o da sonu ölümle sonuçlanabilecek bir deneye katılmayı kabul etmek. Şanslarını denemek isteyen suçlular, uzayda geçecek olan insan üreme deneyinin bir parçası olmayı kabul eder. Ancak hayatta kalmak onlar için hiç de kolay olmayacaktır. İçinde bulundıkları gemi kozmik ışın fırtınasına maruz kalınca suçlular için adeta bir ölüm kalım savaşı başlayacaktır.",CategoriesId=new List<int>{3}},
            new Movie() { Id = 4,Name="Billboard",Description="Times are tough, listener-ship is down and Casey needs to come up with a plan to save his radio station, WTYT 960, and fast! Casey's grand plan is to host a billboard sitting contest, where ... ",ImageUrl="4.jpg",LongDescription="Casey’in başarısız bir radyo istasyonu olan WTYT 960'ı kurtarmak için çok az zamanı vardır. İstasyonu babasından devralmasının ardından onu kurtarmak için ne yapacağından emin olamayan Casey, bir yarışma düzenlemeye karar verir. Casey, dört katılımcının bir ilan panosunun önünde yaşayacağı ve orada en uzun yaşayanın bir mobil ev ve \"dokuz altmış\" bin dolar kazanacağı bir yarışma düzenler.",CategoriesId=new List<int>{5,8}
},
            new Movie() { Id = 5,Name="Storm Boy",Description="Elin's son dies in a drowning accident, but together with her daughter Storm (10) she tries to restart, but when the rumors start that Storm pushed her brother into the water she has to prot...",ImageUrl="5.jpg",LongDescription="DD, 30'lu yaşlarında, kibar olduğu kadar alaycı bir 21. yüzyıl anti-kahramanı. Zeki, hoş, dikkatli ama biraz çıkarcı. Ancak DD'de sanki çok temel bir şeyler eksik. Küçük ve emniyetli dünyasını alt üst edecek olan fırtına da bu yüzden kopacak. Hayatına giren garip bir kadın olan Lova ve peşinde ona zarar vermek isteyen kötü adamlarla DD istemeden kendini giderek daha ürkütücü hale gelen bir dizi olayın içinde bulur. Farkında değildir ama iyi ile kötü arasında bir savaş yaşanmaktadır ve savaş alanı bizzat kendisidir. Bu işin içinden tek parça halinde çıkabilmesi için geçmişiyle ilgili bir bulmacayı çözmesi gerekecektir. Film, kahramanı için olduğu kadar seyircisi için de bir yolculuk niteliğinde. Aksiyon, çizgi roman ve bilgisayar oyunlarından ilham alan, sürekli tarzlar ve türler arasında ustalıkla gidip gelen Fırtına, karanlık ve bilinmeyenlerle dolu bir dünya yaratıyor: kah bilgisayar oyunu kah aksiyon filmi oluveriyor. Ama bütün bunlar, tıpkı Matrix?te olduğu gibi temel bir soruyu sorabilmek içindir: Gerçekle hayali nasıl ayırt edebiliriz?",CategoriesId=new List<int>{1,8}}

            };
        }
        public static List<Movie> Movies
        {
            get
            {
                return _movies;
            }
        }
        public static void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }
        public static Movie? GetByID(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }
    }

}
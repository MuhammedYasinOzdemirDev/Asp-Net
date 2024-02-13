var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();//mvc sablonu tanıtırız
var app = builder.Build();


/*app.MapGet("/", () => "Hello World!");Get requeste basit yazdırma tarzı
app.MapGet("/abc", () => "Hello World!;")
*/
//app.MapDefaultControllerRoute() otonom yapar
app.UseStaticFiles();//wwwroot gibi static dosyaları aktif eder
app.UseRouting();//yonlendirme sıralama dogru olmasını saglar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);//routuing semasi olusturma
app.Run();

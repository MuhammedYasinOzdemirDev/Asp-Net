var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(routes =>
{//hata ayıklama gibi en son alttakini arar
    routes.MapControllerRoute(
       "CourseByRelesead",//route adı
        "courses/relesead/{year}/{month}", //format
        new { controller = "Course", action = "ByRelesead" },//çalışacak metod
         new { year = @"\d{4}", month = @"\d{2}" });//year ve monthun hane sayısı belirlenir yanlış girilirse hata
    routes.MapControllerRoute(
       "default",
        "{controller=Home}/{action=Index}/{id?}");
});


app.Run();

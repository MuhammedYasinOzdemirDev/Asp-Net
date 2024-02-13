using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogContext>(options =>
{
    var config = builder.Configuration;

    var connectionstring = config.GetConnectionString("mysql");
    var version = new MySqlServerVersion(new Version(8, 0, 33));
    options.UseMySql(connectionstring, version);
});
builder.Services.AddScoped<IPostRepository, EfPostRepository>();//IPostRepository çağrıldığında EfPostRepository nesnesi 
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
var app = builder.Build();
SeedData.TestVerileriniDoldur(app);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.UseRouting();
app.MapControllerRoute(
    name: "post_details",
    pattern: "posts/{url}",
    defaults: new { controller = "Posts", action = "Details" });
app.MapControllerRoute(
name: "post_by_tag",
pattern: "post/tag/{tag}",
defaults: new { controller = "Posts", action = "Index" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");
app.Run();


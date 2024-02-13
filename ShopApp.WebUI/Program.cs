var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});
/*app.MapControllerRoute(
name:"default",
pattern:"");*/

app.Run();

using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Controllers;
using ExamMagazinAspNetRazorPage.Storage;
using ExamMagazinAspNetRazorPage.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();                                  // добавление классов контроллеров в IoC-контейнер
builder.Services.AddDbContext<ApplicationDbContext>();              // добавим DbContext
builder.Services.AddTransient<IOrderService, RdbOrderService>();
builder.Services.AddTransient<IProductService, RdbProductService>();
builder.Services.AddTransient<IOrderProductService, RdbOrderProductService>();
builder.Services.AddRazorPages();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

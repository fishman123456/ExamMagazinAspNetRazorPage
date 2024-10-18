using ExamMagazinAspNetRazorPage.Models;
using ExamMagazinAspNetRazorPage.Controllers;
using ExamMagazinAspNetRazorPage.Storage;
using ExamMagazinAspNetRazorPage.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();                                  // ���������� ������� ������������ � IoC-���������
builder.Services.AddDbContext<ApplicationDbContext>();              // ������� DbContext
builder.Services.AddTransient<IOrderService, RdbOrderService>();
builder.Services.AddTransient<IProductService, RdbProductService>();
builder.Services.AddTransient<IOrderProductService, RdbOrderProductService>();
builder.Services.AddTransient<IClientService, RdbClientService>();
builder.Services.AddRazorPages();


var app = builder.Build();
// ��� Views �� 18-10-2024
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

// ��� Razor ����� 18-10-2024
app.MapRazorPages();
app.Run();

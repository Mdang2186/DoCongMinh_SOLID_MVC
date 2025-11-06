using Microsoft.EntityFrameworkCore;
using DoCongMinh.Data;
using DoCongMinh.Repositories;
using DoCongMinh.Repositories.Interfaces;
using DoCongMinh.Services;
using DoCongMinh.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>(); 
builder.Services.AddControllersWithViews();

var app = builder.Build();
 
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();  
app.UseRouting();

app.UseAuthorization(); // Cần cho MVC

// Cấu hình Route (định tuyến) mặc định cho MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");

app.Run();
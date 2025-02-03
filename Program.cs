using Microsoft.EntityFrameworkCore;
using SaiSports.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//DbContext
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
   ));

// Register EmailSender as the IEmailSender service
builder.Services.AddTransient<EmailSender, EmailSender>();
builder.Services.AddControllersWithViews();


//Session
builder.Services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();  

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();




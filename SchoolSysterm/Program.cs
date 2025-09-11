
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolSysterm.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register DbContext + Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication(); // 👈 required for Identity
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Category}/{action=Index}/{id?}");

app.Run();


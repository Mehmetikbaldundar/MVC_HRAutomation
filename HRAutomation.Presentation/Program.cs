using HRAutomation.DataAccess.Abstract;
using HRAutomation.DataAccess.EntityFramework.Concrete;
using HRAutomation.DataAccess.EntityFramework.Context;
using HRAutomation.Presentation.Models.SeedDataFolder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HRAutomationDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Login";
    x.AccessDeniedPath = "/Home/Error";
    x.Cookie = new CookieBuilder
    {
        Name = "NRM1Cookie",
        SecurePolicy = CookieSecurePolicy.Always,
        HttpOnly = true,
    };
    x.ExpireTimeSpan = TimeSpan.FromMinutes(1);
    x.SlidingExpiration = true;
    x.Cookie.MaxAge = x.ExpireTimeSpan;
});

builder.Services.AddScoped<IAdminRepo, AdminRepo>();
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedData.Seed(app);
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

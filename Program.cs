using Ebook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ModelsDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("constr")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ModelsDbContext>();

// builder.Services.AddDefaultIdentity<IdentityUser> 
//     (options => 
// { 
//     options.SignIn.RequireConfirmedAccount = true; 
//     options.Password.RequireDigit = false; 
//     options.Password.RequiredLength = 6; 
//     options.Password.RequireNonAlphanumeric = false; 
//     options.Password.RequireUppercase = false; 
//     options.Password.RequireLowercase = false; 
// }) 
// .AddEntityFrameworkStores<ModelsDbContext>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

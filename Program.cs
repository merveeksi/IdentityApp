using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<IdentityContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionString:SQLite_Connection"]));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    
    options.User.RequireUniqueEmail = true; //email adreslerinin unique olmasını sağlar, başka bir kullanıcı aynı email adresi ile kayıt olamaz
    options.User.AllowedUserNameCharacters = "abcçdefgğhıijklmnoöprsştuüvyzABCÇDEFGĞHİIJKLMNOÖPRSŞTUÜVYZ0123456789-._"; //kullanıcı adı için geçerli karakterler
});

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

IdentitySeedData.IdentityTestUser(app);

app.Run();

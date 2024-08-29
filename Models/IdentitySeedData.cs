using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;

public static class IdentitySeedData
{
    private const string adminUser = "admin";
    
    private const string adminPassword = "Admin_1234";

    public static async void IdentityTestUser(IApplicationBuilder app)
    {
        var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>(); //servis sağlayıcısından IdentityContext sınıfını alıyoruz

        if (context.Database.GetAppliedMigrations().Any())
        {
            context.Database.Migrate();
        }
        
        var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>(); //servis sağlayıcısından UserManager sınıfını alıyoruz

        var user = await userManager.FindByNameAsync(adminUser); //kullanıcı adına göre kullanıcıyı arıyoruz

        if (user == null)
        {
            user = new AppUser
            {
                FullName = "Merve Ekşi",
                UserName = adminUser,
                Email = "admin@merveeksi.com",
                PhoneNumber = "555 444 33 22"
            };
            
            await userManager.CreateAsync(user, adminPassword); // kullanıcıyı oluşturuyoruz //bir parola atansın mı diye soruyor //parolayı göremeyiz
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp.Models;

public class IdentityContext:IdentityDbContext<IdentityUser> //kullanıcı bilgilerini tutan tablo
{
    public IdentityContext(DbContextOptions<IdentityContext> options):base(options) // veritabanı bağlantısı //dışarıdan gelen options parametresini base sınıfına gönderiyoruz
    {
        
    }
}
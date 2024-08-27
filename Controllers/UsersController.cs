using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers;

public class UsersController:Controller
{
    //sayfa üzerinde artık userManager nesnesine erişebiliriz.
    public UsersController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
   
    private UserManager<IdentityUser> _userManager;
    
    public IActionResult Index()
    {
        return View(_userManager.Users);
    }
}
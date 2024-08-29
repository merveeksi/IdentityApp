using IdentityApp.ViewModels;
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

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            };
            
            IdentityResult result = await _userManager.CreateAsync(user, model.Password); //kullanıcıyı oluşturur
            
            if(result.Succeeded) 
            {
                return RedirectToAction("Index");
            }
            foreach (IdentityError err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }
        return View();
    }
}
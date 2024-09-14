using IdentityApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApp.Controllers;

public class RolesController:Controller
{
    private readonly RoleManager<AppRole> _roleManager;
    public RolesController(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }
    
    public IActionResult Index()
     {
         return View(_roleManager.Roles); //filtreleme uygulayabiliriz
         
     } 
    [HttpPost]
    public async Task<IActionResult> Create(AppRole model)
     {
         if(ModelState.IsValid)
         {
             var result = await _roleManager.CreateAsync(model);
             if(result.Succeeded)
             {
                 return RedirectToAction("Index");
             }
             foreach(var error in result.Errors)
             {
                 ModelState.AddModelError("", error.Description);
             }
         }
         return View();
     }
 }
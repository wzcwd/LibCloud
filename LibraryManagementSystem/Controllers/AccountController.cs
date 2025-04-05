using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class AccountController: Controller
{
    private UserManager<User> userManager;
    private SignInManager<User> signInManager;

    public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr)
    {
        userManager = userMngr;
        signInManager = signInMngr;
    }
    
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    
  
    
    
    
    
    
    
    
    
    
    
    
    
    
}
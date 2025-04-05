using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManagementSystem.Controllers;

public class AccountController : Controller
{
    private UserManager<User> userManager;
    private SignInManager<User> signInManager;
    private readonly ILogger<AccountController> logger;

    public AccountController(UserManager<User> userMngr, SignInManager<User> signInMngr, ILogger<AccountController> log)
    {
        userManager = userMngr;
        signInManager = signInMngr;
        logger = log;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Login(string returnUrl = "/")
    {
        LoginViewModel model = new LoginViewModel
        {
            ReturnUrl = returnUrl
        };
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //  avoid CSRF attack
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await signInManager.PasswordSignInAsync(
            model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            logger.LogInformation("User '{Username}' logged in successfully at {Time}.", model.Username, DateTime.Now);
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        logger.LogWarning("Login failed for user '{Username}' at {Time}.", model.Username, DateTime.Now);
        ModelState.AddModelError(string.Empty, "Invalid login, please try again.");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken] //  avoid CSRF attack
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        logger.LogInformation("logged out successfully");
        return RedirectToAction("Login", "Account");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = new User
        {
            UserName = model.Username,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            logger.LogInformation("New user '{Username}' registered successfully at {Time}.", model.Username, DateTime.Now);
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }
}
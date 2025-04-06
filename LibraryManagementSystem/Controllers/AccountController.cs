using System.Security.Claims;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
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
        return RedirectToAction(nameof(Login), "Account");
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
            logger.LogInformation("New user '{Username}' registered successfully at {Time}.", model.Username,
                DateTime.Now);
            await signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }


    public IActionResult ExternalLogin(string provider, string returnUrl = "/")
    {
        var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { returnUrl });
        var properties = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return Challenge(properties, provider); // go the third-party Authentication plateform
    }


    public async Task<IActionResult> ExternalLoginCallback(string returnUrl = "/", string? remoteError = null)
    {
        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, $"External provider error: {remoteError}");
            return RedirectToAction(nameof(Login));
        }

        var info = await signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return RedirectToAction(nameof(Login));
        }

        // try to log in 
        var result =
            await signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
        if (result.Succeeded)
        {
            return Redirect(returnUrl);
        }

        // check if the email already exists
        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var user = await userManager.FindByEmailAsync(email!);
        if (user == null)
        {
            // if user does not exist, create new user
            user = new User { UserName = email, Email = email };
            var createResult = await userManager.CreateAsync(user);
            if (createResult.Succeeded)
            {
                await userManager.AddLoginAsync(user, info);
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect(returnUrl);
            }

            foreach (var error in createResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        else
        {
            // user(email) exists but external login not linked, so link it
            var addLoginResult = await userManager.AddLoginAsync(user, info);
            if (addLoginResult.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return Redirect(returnUrl);
            }

            foreach (var error in addLoginResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View("Login");
    }

    public async Task<IActionResult> UpdateAccount()
    {
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        logger.LogInformation("User with ID '{UserId}' is accessing the account update page.", id);
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = await userManager.FindByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new AccountViewModel()
        {
            Username = user.UserName!,
            Email = user.Email!
        };

        return View("AccountInfo", model); 
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ChangePassword(string CurrentPassword, string NewPassword, string ConfirmPassword)
    {
        if (string.IsNullOrWhiteSpace(CurrentPassword) || string.IsNullOrWhiteSpace(NewPassword) || string.IsNullOrWhiteSpace(ConfirmPassword))
        {
            ModelState.AddModelError("", "All fields are required.");
            return View("AccountInfo");
        }

        if (NewPassword != ConfirmPassword)
        {
            ModelState.AddModelError("", "New password and confirmation do not match.");
            return View("AccountInfo");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await userManager.FindByIdAsync(userId!);
        if (user == null)
        {
            return NotFound();
        }

        var result = await userManager.ChangePasswordAsync(user, CurrentPassword, NewPassword);

        if (result.Succeeded)
        {
            await signInManager.RefreshSignInAsync(user); // Refresh the login session
            ViewData["PasswordChangeSuccess"] = "Password changed successfully.";
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        var model = new AccountViewModel()
        {
            Username = user.UserName!,
            Email = user.Email!
        };

        return View("AccountInfo", model);
    }
}
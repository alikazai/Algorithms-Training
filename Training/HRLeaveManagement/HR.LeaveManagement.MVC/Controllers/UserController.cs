using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;
public class UserController : Controller
{
    private readonly IAuthenticationService _authService;

    public UserController(IAuthenticationService authService)
    {
        _authService = authService;
    }

    public IActionResult Login(string returnUrl = null)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM login, string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        var isLoggedIn = await _authService.Authenticae(login.Email, login.Password);
        if (isLoggedIn)
            return LocalRedirect(returnUrl);

        ModelState.AddModelError("", "Log in Attempt Failed. Please try again");
        return View(login);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM registration)
    {
        if (ModelState.IsValid)
        {
            var returnUrl = Url.Content("~/");
            var isCreated = await _authService.Register(registration.FirstName, registration.LastName,
                registration.UserName, registration.Email, registration.Password);

            if (isCreated)
                return LocalRedirect(returnUrl);
        }

        ModelState.AddModelError("", "Registration Attempt Failed. Please try again");
        return View(registration);
    }

    [HttpPost]
    public async Task<IActionResult> Logout(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        await _authService.Logout();
        return LocalRedirect(returnUrl);
    }
}

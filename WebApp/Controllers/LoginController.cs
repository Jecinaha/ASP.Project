using Business.Dtos;
using Business.Interfaces;
using Business.Services;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class LoginController(IAuthService authService) : Controller
{
    private readonly IAuthService _authService = authService;

    public IActionResult Login(string returnUrl = "~/")
    {
        ViewBag.ReturnUrl = returnUrl;

        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl ="~/")
    {

        ViewBag.ErrorMessage = null;
        ViewBag.ReturnUrl = returnUrl;

        if (!ModelState.IsValid)
            return View(model);

        var loginFormData = model.MapTo<LoginFormData>();
        var result = await _authService.SignInAsync(loginFormData);
        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl);
        }

        ViewBag.ErrorMessage = result.Error;
        return View(model);
    }

}

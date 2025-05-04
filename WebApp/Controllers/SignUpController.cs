using Business.Dtos;
using Business.Interfaces;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class SignUpController(IAuthService authService) : Controller
{

    private readonly IAuthService _authService = authService;

    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {

        ViewBag.ErrorMessage = null;

        try
        {
            if (!ModelState.IsValid)
                return View(model);

            var signUpFormData = model.MapTo<SignUpFormData>();
            var result = await _authService.SignUpAsync(signUpFormData);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Login");
            }

            ViewBag.ErrorMessage = result.Error;
        }
        catch(Exception ex)
        {
            ViewBag.ErrorMessage = ex.Message;
        }
        return View(model);
    }
   
}

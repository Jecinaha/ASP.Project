

using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.SqlServer.Server;

namespace Business.Services;

public class AuthService(IUserService userService, SignInManager<UserEntity> signInManager) : IAuthService
{
    private readonly IUserService _userService = userService;

    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    public async Task<AuthResult> SignInAsync(LoginFormData formData)
    {
        if (formData == null)
            return new AuthResult { Succeeded = false, StatusCode = 400, Error = "Not all required fields are filled." };

        var result = await _signInManager.PasswordSignInAsync(
            formData.Email,
            formData.Password,
            isPersistent: formData.RememberMe,
            lockoutOnFailure: false);
        return result.Succeeded
            ? new AuthResult { Succeeded = true, StatusCode = 200 }
            : new AuthResult { Succeeded = false, StatusCode = 401, Error = "Invalid email or password" };
    }

    public async Task<AuthResult> SignUpAsync(SignUpFormData formData)
    {
        if (formData == null)
            return new AuthResult { Succeeded = false, StatusCode = 400, Error = "Form data is null." };

        // TODO: Vad skulle användas här?
        //var result = await _signInManager.CreateUserAsync(formData, formData.Password);
        //return result.Succeeded
        //   ? new AuthResult { Succeeded = true, StatusCode = 201 }
        //   : new AuthResult { Succeeded = false, StatusCode = 400, Error = result.Error };
        return null;
    }


    public async Task<AuthResult> SignOutAsync()
    {
        await _signInManager.SignOutAsync();
        return new AuthResult { Succeeded = true, StatusCode = 200 };
    }
}



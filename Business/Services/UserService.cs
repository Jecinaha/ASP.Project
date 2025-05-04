

using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;
using Domain.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;

namespace Business.Services;

public class UserService(IUserRepository userRepository, SignInManager<UserEntity> userManager) : IUserService {
    private readonly IUserRepository _userRepository = userRepository;
    private readonly SignInManager<UserEntity> _userManager = userManager;

    public async Task<UserResult> GetUsersAsync()
    {
        var result = await _userRepository.GetAllAsync();
        return result.MapTo<UserResult>();
    }


    public async Task<UserResult> CreateUserAsync(SignUpFormData formData)
    {
        if (formData == null)
            return new UserResult { Succeeded = false, StatusCode = 400, Error = "Form data is null." };

        var existsResult = await _userRepository.ExistAsync(x => x.Email == formData.Email);
        if (existsResult.Succeeded)
            return new UserResult { Succeeded = false, StatusCode = 409, Error = "User already exists." };

        try
        {
            var userEntity = formData.MapTo<UserEntity>();

            //var result = await _userManager.CreateAsync(userEntity, formData.Password);
            //return result.Succeeded
            //    ? new UserResult { Succeeded = true, StatusCode = 201 }
            //    : new UserResult { Succeeded = false, StatusCode = 500, Error = "Unable to create user." };
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return new UserResult { Succeeded = false, StatusCode = 500, Error = ex.Message };
        }
    }
}

public interface IUserService
{
}
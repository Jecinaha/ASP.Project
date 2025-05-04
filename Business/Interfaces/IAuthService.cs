using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> SignInAsync(LoginFormData formData);
        Task<AuthResult> SignOutAsync();
        Task<AuthResult> SignUpAsync(SignUpFormData formData);
    }
}
using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserResult> CreateUserAsync(SignUpFormData formData);
        Task<UserResult> GetUsersAsync();
    }
}
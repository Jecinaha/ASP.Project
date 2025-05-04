using Business.Dtos;
using CloudinaryDotNet.Actions;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<UserResult> CreateUserAsync(SignUpFormData formData);
        Task<UserResult> GetUsersAsync();
    }
}
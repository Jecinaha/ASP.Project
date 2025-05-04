using Business.Dtos;
using Business.Models;
using Data.Models;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectResult> CreateProjectAsync(AddProjectFormData formData);
        Task<ProjectResult> DeleteProjectAsync(string id);
        Task<ProjectResult<Project>> GetProjectAsync(string id);
        Task<ProjectResult<IEnumerable<Project>>> GetProjectsAsync();
        Task<ProjectResult> UpdateProjectAsync(string id, UpdateProjectFormData formData);
    }
}
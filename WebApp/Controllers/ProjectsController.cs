using Business.Dtos;
using Business.Interfaces;
using Domain.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ProjectsController(IProjectService projectService) : Controller
{
    private readonly IProjectService _projectService = projectService;

    [Route("projects")]
    public async Task<IActionResult> Projects()
    {
        var projects = await _projectService.GetProjectsAsync();
        var model = new ProjectsViewModel
        {
            Projects = projects.Result.MapTo<IEnumerable<ProjectViewModel>>(),
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProjectViewModel model)
    {
        var addProjectFormData = model.MapTo<AddProjectFormData>();

        var result = await _projectService.CreateProjectAsync(addProjectFormData);

        return Json(new { });
    }

    [HttpPost]
    public async Task<IActionResult> Update(EditProjectViewModel model)
    {
        var updateProjectFormData = model.MapTo<UpdateProjectFormData>();

        var result = await _projectService.UpdateProjectAsync(updateProjectFormData.Id, updateProjectFormData);

        return Json(new { });
    }

    [HttpPost]
    public IActionResult Delete(string id)
    {

        return Json(new { });
    }
}

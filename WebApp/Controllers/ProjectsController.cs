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
        if (projects == null || projects.Result == null)
        {
            return NotFound();
        }

        var model = new ProjectsViewModel
        {
            Projects = projects.Result.Select(x =>
            {
                return new ProjectViewModel
                {
                    Id = x.Id,
                    ProjectImage = x.Image,
                    ProjectName = x.ProjectName,
                    ClientName = x.Client?.ClientName,
                    Description = x.Sescription,
                    TimeLeft = (x.EndDate - x.StartDate).Days.ToString(),
                };
            })
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddProjectViewModel model)
    {
        AddProjectFormData addProjectFormData = model.MapTo<AddProjectFormData>();
        var result = await _projectService.CreateProjectAsync(addProjectFormData);
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Update(EditProjectViewModel model)
    {
        var updateProjectFormData = model.MapTo<UpdateProjectFormData>();
        var result = await _projectService.UpdateProjectAsync(updateProjectFormData.Id, updateProjectFormData);
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(string id)
    {
        Business.Models.ProjectResult result = await _projectService.DeleteProjectAsync(id);
        return RedirectToAction("Projects", "Projects");
    }
}

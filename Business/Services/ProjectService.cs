
using Azure.Core;
using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;
using Data.Repositories;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<ProjectResult> CreateProjectAsync(AddProjectFormData formData)
    {
        if (formData == null)
        {
            return new ProjectResult { Succeeded = false, StatusCode = 400, Error = "Form data is null." };
        }
        var projectEntity = formData.MapTo<ProjectEntity>();

        var result = await _projectRepository.AddAsync(projectEntity);
        return result.Succeeded
            ? new ProjectResult { Succeeded = true, StatusCode = 201 }
            : new ProjectResult { Succeeded = false, StatusCode = 400, Error = result.Error };
    }

    public async Task<ProjectResult> UpdateProjectAsync(string id, UpdateProjectFormData formData)
    {
        if (formData == null)
        {
            return new ProjectResult { Succeeded = false, StatusCode = 400, Error = "Form data is null." };
        }
        var projectEntity = formData.MapTo<ProjectEntity>();
        projectEntity.Id = id;
        var result = await _projectRepository.UpdateAsync(projectEntity);
        return result.Succeeded
            ? new ProjectResult { Succeeded = true, StatusCode = 200 }
            : new ProjectResult { Succeeded = false, StatusCode = 400, Error = result.Error };
    }

    public async Task<ProjectResult<IEnumerable<Project>>> GetProjectsAsync()
    {
        var response = await _projectRepository.GetAllAsync(orderByDescending: true, sortBy: s => s.Created, where: null, include => include.User, include => include.Status, include => include.Client);

        return new ProjectResult<IEnumerable<Project>> { Succeeded = true, StatusCode = 200, Result = response.Result };
    }

    public async Task<ProjectResult<Project>> GetProjectAsync(string id)
    {
        var response = await _projectRepository.GetAsync(
            where: x => x.Id == id,
            include => include.User,
            include => include.Status,
            include => include.Client
            );

        return response.Succeeded
            ? new ProjectResult<Project> { Succeeded = true, StatusCode = 200, Result = response.Result }
            : new ProjectResult<Project> { Succeeded = false, StatusCode = 404, Error = $"Project '{id}' was not found." };
    }


    public async Task<ProjectResult> DeleteProjectAsync(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            return new ProjectResult
            {
                Succeeded = false,
                StatusCode = 400,
                Error = "Invalid project ID."
            };
        }

        var getResult = await _projectRepository.GetAsync(x => x.Id == id);

        if (!getResult.Succeeded || getResult.Result == null)
        {
            return new ProjectResult
            {
                Succeeded = false,
                StatusCode = 404,
                Error = $"Project with ID '{id}' was not found."
            };
        }

        var project = getResult.Result;


        // TODO: Mappa project till projectEntity
        //var deleteResult = await _projectRepository.DeleteAsync(project);
        var deleteResult = await _projectRepository.DeleteAsync(null);

        if (!deleteResult.Succeeded || !deleteResult.Result)
        {
            return new ProjectResult
            {
                Succeeded = false,
                StatusCode = 500,
                Error = deleteResult.Error ?? "Failed to delete the project."
            };
        }

        return new ProjectResult
        {
            Succeeded = true,
            StatusCode = 204
        };
    }



}


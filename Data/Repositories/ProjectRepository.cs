using Data.Contexts;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;

namespace Data.Repositories;

public class ProjectRepository(AppDbContext context) : BaseRepository<ProjectEntity, Project>(context), IProjectRepository
{
}

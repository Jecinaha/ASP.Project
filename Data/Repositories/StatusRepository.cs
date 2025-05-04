using Data.Contexts;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;

namespace Data.Repositories;

public class StatusRepository(AppDbContext context) : BaseRepository<StatusEntity, Status>(context), IStatusRepository
{
}

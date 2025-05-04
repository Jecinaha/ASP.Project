using Data.Contexts;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;

namespace Data.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<UserEntity, User>(context), IUserRepository
{
  
}

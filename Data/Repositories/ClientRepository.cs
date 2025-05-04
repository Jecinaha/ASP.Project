using Data.Contexts;
using Data.Entities;
using Data.Ïnterfaces;
using Data.Models;

namespace Data.Repositories;

public class ClientRepository(AppDbContext context) : BaseRepository<ClientEntity,  Client>(context), IClientRepository
{
}

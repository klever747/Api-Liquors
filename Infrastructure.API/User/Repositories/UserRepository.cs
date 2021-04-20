using Application.API.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.API.Contexts;

namespace Infrastructure.API.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using Application.API.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.API.Contexts;

namespace Infrastructure.API.Repositories
{
    public class SalesRepository : Repository<Sales>, ISalesRepository
    {
        public SalesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

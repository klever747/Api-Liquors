using Application.API.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.API.Contexts;

namespace Infrastructure.API.Repositories
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

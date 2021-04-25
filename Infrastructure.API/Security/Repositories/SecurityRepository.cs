using Domain.Entities;
using Infrastructure.API.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.API.Repositories
{
    public class SecurityRepository : Repository<Security>, ISecurityRepository
    {
        public SecurityRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _context.Securities.FirstOrDefaultAsync(x => x.Users == login.User && x.Passwordu == login.Password);
        }
    }
}

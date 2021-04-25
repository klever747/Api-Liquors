using Application.API.Interfaces.Repositories;
using Domain.Entities;
using System.Threading.Tasks;

namespace Infrastructure.API.Repositories
{
    public interface ISecurityRepository:IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
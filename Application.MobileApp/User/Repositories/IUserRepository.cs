using System.Net.Http;
using System.Threading.Tasks;

namespace Application.MobileApp.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<(bool, object)> CreateAsync(string requestUri, StringContent content);

        Task<bool> DeleteByIdAsync(string requestUri);

        Task<(bool, object)> GetAllAsync(string requestUri);

        Task<bool> UpdateAsync(string requestUri, StringContent content);
    }
}

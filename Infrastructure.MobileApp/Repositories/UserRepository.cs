using Application.MobileApp.Interfaces.Repositories;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.MobileApp.Repositories
{
    public class UserRepository : Repository, IUserRepository
    {
        #region Constructors

        public UserRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        #endregion Constructors

        #region Methods

        public async Task<(bool, object)> CreateAsync(string requestUri, StringContent content) => await PostAsync(requestUri, content);

        public async Task<bool> DeleteByIdAsync(string requestUri) => await DeleteAsync(requestUri);

        public async Task<(bool, object)> GetAllAsync(string requestUri) => await GetAsync(requestUri);

        public async Task<bool> UpdateAsync(string requestUri, StringContent content) => await PutAsync(requestUri, content);

        #endregion Methods
    }
}

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.MobileApp.Repositories
{
    public abstract class Repository
    {
        #region Properties

        public HttpClient _httpClient;

        #endregion Properties

        #region Constructrors

        public Repository(HttpClient httpClient) => _httpClient = httpClient;

        #endregion Constructrors

        #region Methods

        public async Task<bool> DeleteAsync(string requestUri)
        {
            try
            {
                var httpResponse = await _httpClient.DeleteAsync(requestUri);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<(bool, object)> GetAsync(string requestUri)
        {
            try
            {
                var httpResponse = await _httpClient.GetAsync(requestUri);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return (false, null);
                }

                var contentResponse = await httpResponse.Content.ReadAsStringAsync();

                return (true, contentResponse);
            }
            catch (Exception e)
            {
                return (false, null);
            }
        }

        public async Task<(bool, object)> PostAsync(string requestUri, StringContent content)
        {
            try
            {
                var httpResponse = await _httpClient.PostAsync(requestUri, content);
                if (!httpResponse.IsSuccessStatusCode)
                {
                    return (false, null);
                }

                var contentResponse = await httpResponse.Content.ReadAsStringAsync();

                return (true, contentResponse);
            }
            catch
            {
                return (false, null);
            }
        }

        public async Task<bool> PutAsync(string requestUri, StringContent content)
        {
            try
            {
                var httpResponse = await _httpClient.PutAsync(requestUri, content);

                return httpResponse.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        #endregion Methods
    }
}

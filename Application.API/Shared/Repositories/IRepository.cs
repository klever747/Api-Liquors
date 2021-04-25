using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.API.Interfaces.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<bool> DeleteAsync(int  id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int  id);

        Task<T> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);
        Task SaveChangesAsync();
    }
}

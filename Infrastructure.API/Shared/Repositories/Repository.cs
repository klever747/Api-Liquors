using Application.API.Interfaces.Repositories;
using Infrastructure.API.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.API.Repositories
{
    public class Repository<T>:IRepository<T> where T :class
    {
        #region Fields
        protected readonly ApplicationDbContext _context;
        #endregion
        #region Constructors
        public Repository(ApplicationDbContext context) => _context = context;
        #endregion
        #region Methods
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
            {
                return false;
            }

            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToArrayAsync();

        public async Task<T> GetByIdAsync(int  id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch(Exception e )
            {
                return null;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}

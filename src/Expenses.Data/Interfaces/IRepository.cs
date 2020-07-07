using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.Data
{
    public interface IRepository<T> where T : new()
    {
        #region Sync Methods

        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByFilter(Func<T, bool> predicate);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);

        #endregion

        #region Async Methods

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetByFilterAsync(Func<T, bool> predicate);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task DeleteAsync(T obj);

        #endregion
    }
}

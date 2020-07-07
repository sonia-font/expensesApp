using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Data
{
    public class Repository<T> : IRepository<T> where T : Entity, new()
    {
        #region Members

        protected IDataContext dataContext;

        #endregion

        #region Constructors

        public Repository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        #endregion

        #region IRepository Implementation

        public T Add(T obj) => dataContext.Add(obj);

        public Task<T> AddAsync(T obj) => Task.FromResult(Add(obj));

        public void Delete(T obj) => dataContext.Delete(obj);

        public Task DeleteAsync(T obj)
        {
            Delete(obj);
            return Task.CompletedTask;
        }

        public IEnumerable<T> GetAll() => dataContext.GetAll<T>();

        public Task<IEnumerable<T>> GetAllAsync() => Task.FromResult(GetAll());

        public IEnumerable<T> GetByFilter(Func<T, bool> predicate) => dataContext.GetAll<T>().Where(predicate);

        public Task<IEnumerable<T>> GetByFilterAsync(Func<T, bool> predicate) => Task.FromResult(GetByFilter(predicate));

        public T GetById(int id) => dataContext.Get<T>(id);

        public Task<T> GetByIdAsync(int id) => Task.FromResult(GetById(id));

        public T Update(T obj) => dataContext.Update(obj);

        public Task<T> UpdateAsync(T obj) => Task.FromResult(Update(obj));

        #endregion
    }
}

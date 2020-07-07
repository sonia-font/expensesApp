using System.Collections.Generic;

namespace Expenses.Data
{
    public interface IDataContext
    {
        #region Methods

        IEnumerable<T> GetAll<T>() where T : Entity;
        T Get<T>(int id) where T : Entity;
        T Add<T>(T obj) where T : Entity;
        T Update<T>(T obj) where T : Entity;
        void Delete<T>(T obj) where T : Entity;

        #endregion
    }
}

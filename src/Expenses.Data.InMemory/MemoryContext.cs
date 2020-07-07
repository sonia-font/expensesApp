using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Data.InMemory
{
    public class MemoryContext : IDataContext
    {
        #region Members

        static int lastId = 0;

        #endregion

        #region Methods

        public T Add<T>(T obj) where T : Entity
        {
            lastId++;
            obj.Id = lastId;
            MemorySet<T>.Data.Add(obj.Id, obj);
            return obj;
        }

        public void Delete<T>(T obj) where T : Entity
        {
            MemorySet<T>.Data.Remove(obj.Id);
        }

        public T Get<T>(int id) where T : Entity
        {
            return MemorySet<T>.Data.Values.FirstOrDefault(obj => obj.Id == id);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return MemorySet<T>.Data.Values;
        }

        public T Update<T>(T obj) where T : Entity
        {
            MemorySet<T>.Data[obj.Id] = obj;
            return obj;
        }

        #endregion
    }

    #region Dictionary

    class MemorySet<T>
    {
        static MemorySet()
        {
            Data = new Dictionary<int, T>();
        }

        public static IDictionary<int, T> Data { get; }
    }

    #endregion
}

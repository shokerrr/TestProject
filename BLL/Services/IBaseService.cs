using BLL.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        void Remove(T item);
        void Update(T item);
        IEnumerable<T> GetByFilters(StorageFilters ?filters);
    }
}

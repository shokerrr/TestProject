using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T FindById(int id);
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}

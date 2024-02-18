using DAL.Entities;
using DAL.Migrations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        protected DbSet<T> _entites;

        protected ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entites = _context.Set<T>();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _entites;
        }

        public virtual T FindById(int id)
        {
            return _entites.Find(id);
        }

        public virtual void Add(T item)
        {
            _entites.Add(item);
            _context.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
             _entites.AddRange(items);
             _context.SaveChanges();
        }

        public virtual void Update(T item)
        {
            _entites.Update(item);
            _context.SaveChanges();
        }

        public virtual void Delete(T item)
        {
            _entites.Remove(item);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

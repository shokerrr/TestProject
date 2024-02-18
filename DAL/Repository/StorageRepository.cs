using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class StorageRepository: BaseRepository<Storage>, IStorageRepository
    {
        public StorageRepository(ApplicationDbContext context): base(context) 
        {
        }

        public void AddRange(IEnumerable<Storage> items)
        {
            _entites.AddRange(items);
            _context.SaveChanges();
        }

        public void Empty()
        {
            foreach (Storage item in _entites)
            {
                _entites.Remove(item);
            }
            _context.SaveChanges();
        }
    }
}

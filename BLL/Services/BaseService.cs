using AutoMapper;
using BLL.DTO;
using BLL.Object;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BaseService<T, D> : IBaseService<T> where T : StorageDTO where D : Storage
    {
        protected readonly IBaseRepository<D> _repo;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<D> repo)
        {
            _repo = repo;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<D, T>();
                cfg.CreateMap<D, T>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public void Add(T item)
        {
            _repo.Add(_mapper.Map<T, D>(item));
        }

        public virtual void AddRange(IEnumerable<T> items)
        {
            _repo.AddRange(_mapper.Map<IEnumerable<T>, IEnumerable<D>>(items));
        }

        public T FindById(int id)
        {
            return _mapper.Map<D, T>(_repo.FindById(id));
        }

        public IEnumerable<T> GetAll()
        {
            return _mapper
                .Map<IEnumerable<D>, IEnumerable<T>>(_repo.GetAll());
        }

        public IEnumerable<T> GetByFilters(StorageFilters? filters)
        {
            var res = GetAll();

            if (filters != null)
            {
                res.Where(x => (filters.Ids == null || (filters.Ids != null && filters.Ids.Contains(x.Id)))
                && (filters.Values == null || (filters.Values != null && filters.Values.Contains(x.Value)))).ToList();
            }

            return GetAll();
        }

        public void Remove(T item)
        {
            _repo.Delete(_mapper.Map<T, D>(item));
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            _repo.Update(_mapper.Map<T, D>(item));
        }
    }
}

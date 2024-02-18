using AutoMapper;
using BLL.DTO;
using BLL.Object;
using DAL.Entities;
using DAL.Repository;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StorageService : BaseService<StorageDTO, Storage>, IStorageService
    {
        public StorageService(IStorageRepository repo) : base(repo)
        {
        }

        public override void AddRange(IEnumerable<StorageDTO> items)
        {
            _repo.AddRange(_mapper.Map<IEnumerable<StorageDTO>, IEnumerable<Storage>>(items.OrderBy(x => x.Code)));
        }
    }
}

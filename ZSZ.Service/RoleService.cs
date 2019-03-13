using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;
using ZSZ.IService;
using ZSZ.Service.Data;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
    public class RoleService : IRoleService
    {
        public RoleDTO[] GetAll()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> baseService = new BaseService<RoleEntity>(dbContext);
                var entitylist = baseService.GetAll();
                return entitylist.ToList().Select(x => ToDto(x)).ToArray();
            }  
        }

        public RoleDTO GetById(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> baseService = new BaseService<RoleEntity>(dbContext);
                return ToDto(baseService.GetById(id));
            }
        }

        public RoleDTO ToDto(RoleEntity roleEntity)
        {
            RoleDTO roleDTO = new RoleDTO();
            roleDTO.Name = roleEntity.Name;
            return roleDTO;
        }
    }
}

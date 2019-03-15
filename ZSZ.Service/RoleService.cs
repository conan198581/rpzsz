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
            roleDTO.Id = roleEntity.Id;
            roleDTO.CreateDateTime = roleEntity.CreateTime;
            return roleDTO;
        }

        public void Add(string name, long[] permissionIds)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> baseService = new BaseService<RoleEntity>(dbContext);
                RoleEntity roleEntity = new RoleEntity() { Name = name };
                baseService.Add(roleEntity);
                BaseService<PermissionEntity> permissionService = new BaseService<PermissionEntity>(dbContext);
                /*
                 * 连接数据库的操作太多 不建议这样使用
                var plist = permissionService.GetAll();
                foreach (var pid in permissionIds)
                {
                    var permissionObj = plist.SingleOrDefault(x => x.Id == pid);
                    item.PermissionEntities.Add(permissionObj);

                }*/
                var permissionList = permissionService.GetAll().Where(x => permissionIds.Contains(x.Id)).ToArray();
                foreach (var permissionObj in permissionList)
                {
                    roleEntity.PermissionEntities.Add(permissionObj);
                }
                dbContext.SaveChanges();
            }
        }

        public void UpdateRole(RoleDTO roleDTO)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> baseService = new BaseService<RoleEntity>(dbContext);
                var roleEntity = baseService.GetById(roleDTO.Id);
                roleEntity.Name = roleDTO.Name;
                dbContext.SaveChanges();
            }
        }

        public void Del(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> baseService = new BaseService<RoleEntity>(dbContext);
                baseService.MarkDelete(id);
            }
        }
    }
}

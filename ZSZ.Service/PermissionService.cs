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
    public class PermissionService : IPermissionService
    {
        public PermissionDTO[] GetAllPermission()
        {
            using (MyDbContext myDbContext = new MyDbContext())
            {
                BaseService<PermissionEntity> baseService = new BaseService<PermissionEntity>(myDbContext);
                return baseService.GetAll().ToList().Select(x => ToDto(x)).ToArray();
            }
        }

        public int AddPermission(PermissionDTO permissionDTO)
        {
            using (MyDbContext myDbContext = new MyDbContext())
            {
                BaseService<PermissionEntity> baseService = new BaseService<PermissionEntity>(myDbContext);
                PermissionEntity permission = new PermissionEntity();
                permission.Name = permissionDTO.Name;
                permission.Description = permissionDTO.Description;
                return baseService.Add(permission);
            }
        }

        public PermissionDTO ToDto(PermissionEntity permissionEntity)
        {
            PermissionDTO dto = new PermissionDTO();
            dto.Id = permissionEntity.Id;
            dto.Name = permissionEntity.Name;
            dto.Description = permissionEntity.Description;
            dto.CreateDateTime = permissionEntity.CreateTime;
            return dto;
        }
    }
}

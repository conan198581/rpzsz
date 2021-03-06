﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void DeletePermission(long id)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<PermissionEntity> baseService = new BaseService<PermissionEntity>(dbContext);
                baseService.MarkDelete(id);
            }
        }

        public PermissionDTO GetById(long id)
        {
            using (MyDbContext context = new MyDbContext())
            {
                BaseService<PermissionEntity> baseService = new BaseService<PermissionEntity>(context);
                var entity = baseService.GetById(id);
                if (entity == null)
                {
                    throw new ArgumentException("没有相关对象");
                }
                return ToDto(entity);
            }
        }

        public void Update(long id, string name, string description)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<PermissionEntity> baseService = new BaseService<PermissionEntity>(dbContext);
                var entity = baseService.GetById(id);
                entity.Name = name;
                entity.Description = description;
                dbContext.SaveChanges();
            }
        }

        public PermissionDTO[] GetPermissionByRoleId(long roleId)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> bs = new BaseService<RoleEntity>(dbContext);
                return bs.GetById(roleId).PermissionEntities.ToList().Select(p => ToDto(p)).ToArray();
            }
        }

        public void UpdatePermissionsByRoleId(long roleId, long[] permissionIds)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<RoleEntity> roleBaseService = new BaseService<RoleEntity>(dbContext);
                var roleEntity = roleBaseService.GetById(roleId);
                roleEntity.PermissionEntities.Clear();
                BaseService<PermissionEntity> permissionBaseService = new BaseService<PermissionEntity>(dbContext);
                var permissionList = permissionBaseService.GetAll().Where(x => permissionIds.Contains(x.Id)).ToArray();
                foreach (var permissionObj in permissionList)
                {
                    roleEntity.PermissionEntities.Add(permissionObj);
                }
                dbContext.SaveChanges(); 
            }
        }


        
    }
}

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
    public class AdminUserService : IAdminUserService
    {
        public long AddAdminUser(string name, string phoneNum, string password, string email, long? cityId)
        {
            throw new NotImplementedException();
        }

        public AdminUserDTO[] GetAll()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<AdminUserEntity> baseService = new BaseService<AdminUserEntity>(dbContext);
                return baseService.GetAll().ToList().Select(x => ToDTO(x)).ToArray();
            }
        }

        public bool CheckExistByPhone(string phoneNum)
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<AdminUserEntity> baseService = new BaseService<AdminUserEntity>(dbContext);
                return baseService.GetAll().Any(x => x.PhoneNum == phoneNum);
            }
        }

        public AdminUserDTO ToDTO(AdminUserEntity adminUserEntity)
        {
            AdminUserDTO adminUserDTO = new AdminUserDTO();
            adminUserDTO.Id = adminUserEntity.Id;
            adminUserDTO.Name = adminUserEntity.Name;
            adminUserDTO.PhoneNum = adminUserEntity.PhoneNum;
            adminUserDTO.Email = adminUserEntity.Emai;
            adminUserDTO.CreateDateTime = adminUserEntity.CreateTime;
            adminUserDTO.LoginErrorTimes = adminUserEntity.LoginErrorTimes;
            adminUserDTO.LastLoginErrorDateTime = adminUserEntity.LastLoginErrorDateTime;
            adminUserDTO.CityId = adminUserEntity.CityId;
            adminUserDTO.CityName = adminUserEntity.CityEntity.Name;
            return adminUserDTO;
        }
    }
}

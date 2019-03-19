using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.IService;
using ZSZ.Service.Data;
using ZSZ.Service.Entities;
using ZSZ.DTO;

namespace ZSZ.Service
{
    public class CityService : ICityService
    {
        public long AddNew(string cityName)
        {
            using (MyDbContext ctx = new MyDbContext())
            {
                BaseService<CityEntity> baseService = new BaseService<CityEntity>(ctx);
                var cityItem = baseService.GetAll().Any(x => x.Name == cityName);
                if (cityName == null)
                {
                    throw new Exception("该城市已经存在");
                }
                CityEntity cityEntity = new CityEntity();
                cityEntity.Name = cityName;
                ctx.CityEntities.Add(cityEntity);
                ctx.SaveChanges();
                return cityEntity.Id;
            }
        }

        public CityDTO[] GetAll()
        {
            using (MyDbContext dbContext = new MyDbContext())
            {
                BaseService<CityEntity> baseService = new BaseService<CityEntity>(dbContext);
                return baseService.GetAll().ToList().Select(x => ToDto(x)).ToArray();
            }
        }

        public CityDTO ToDto(CityEntity cityEntity)
        {
            CityDTO cityDTO = new CityDTO();
            cityDTO.Id = cityEntity.Id;
            cityDTO.Name = cityEntity.Name;
            cityDTO.CreateDateTime = cityEntity.CreateTime;
            return cityDTO;
        }
    }
}

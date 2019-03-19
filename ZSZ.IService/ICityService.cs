﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface ICityService:IServiceSupport
    {
        long AddNew(string cityName);
        CityDTO[] GetAll();
    }
}

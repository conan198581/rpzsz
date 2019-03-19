using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.DTO;

namespace ZSZ.AdminWeb.Models
{
    public class UserAddViewModel
    {
        public List<CityDTO> CityDTOs { get; set; }
        public List<RoleDTO> RoleDTOs { get; set; }
    }
}
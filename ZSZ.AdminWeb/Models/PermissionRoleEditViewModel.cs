using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZSZ.DTO;

namespace ZSZ.AdminWeb.Models
{
    public class PermissionRoleEditViewModel
    {
        public RoleDTO RoleDTO { get; set; }
        public PermissionDTO[] PermissionDTOs { get; set; }
        public PermissionDTO[] SelectedPermissionDTOs { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;

namespace ZSZ.IService
{
    public interface IRoleService:IServiceSupport
    {
        RoleDTO[] GetAll();
        RoleDTO GetById(long id);
        void Add(string name, long[] permissionIds);
        void UpdateRole(RoleDTO roleDTO);
        void Del(long id);
    }
}

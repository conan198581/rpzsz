using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.DTO;


namespace ZSZ.IService
{
    public interface IPermissionService : IServiceSupport
    {
        PermissionDTO[] GetAllPermission();
        int AddPermission(PermissionDTO permissionDTO);
        void DeletePermission(long id);
        PermissionDTO GetById(long id);
        void Update(long id, string name, string description);
    }
}

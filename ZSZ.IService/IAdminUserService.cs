using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZSZ.IService
{
    public interface IAdminUserService:IServiceSupport
    {
        //加入一个用户，name用户姓名，phoneNum手机号，password密码，email，cityId城市id（null表示总部）
        long AddAdminUser(string name, string phoneNum, string password, string email, long? cityId);
        //
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Data;
using ZSZ.Service.Entities;

namespace ZSZ.Service
{
	public class BaseService<T> where T:BaseEntity
	{
		private MyDbContext myDbContext;
		public BaseService(MyDbContext myDbContext)
		{
			this.myDbContext = myDbContext;
		}
		/// <summary>
		/// 获取所有没有伪删除的数据
		/// </summary>
		/// <returns></returns>
		public IQueryable<T> GetAll()
		{
			return myDbContext.Set<T>().Where(x => x.IsDeleted == false);
		}

	}
}

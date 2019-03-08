using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Data;
using ZSZ.Service.Entities;
using ZSZ.IService;


namespace ZSZ.Service
{
	public class BaseService<T>: IServiceSupport where T:BaseEntity
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

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <returns></returns>
        public long GetTotalCount()
        {
            return GetAll().LongCount();
        }

        /// <summary>
        /// 获取从多少条开始 取多少条的记录
        /// </summary>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IQueryable<T> GetPageList(int startIndex, int count)
        {
            return GetAll().OrderBy(x => x.CreateTime).Skip(startIndex).Take(count);
        }

        /// <summary>
        /// 通过id查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetById(long id)
        {
            return GetAll().Where(x => x.Id == id).SingleOrDefault();
        }

        /// <summary>
        /// 伪删除某条记录
        /// </summary>
        /// <param name="id"></param>
        public void MarkDelete(long id)
        {
            T item = GetById(id);
            item.IsDeleted = true;
            myDbContext.SaveChanges();
        }

        public int Add(T item)
        {
            myDbContext.Set<T>().Add(item);
            var i = myDbContext.SaveChanges();
            return i;
        }
        
        


	}
}

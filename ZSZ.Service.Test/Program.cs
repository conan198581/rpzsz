using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZSZ.Service.Data;

namespace ZSZ.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyDbContext myDbContext = new MyDbContext())
            {
                int cout = myDbContext.SettingsEntities.Count();
                Console.WriteLine(cout);
            }
            Console.WriteLine("ok");
            Console.ReadKey();
        }
    }
}

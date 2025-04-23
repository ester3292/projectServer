using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalClassService:IDallClass
    {
        dbcontext dbcontext;
        public DalClassService(dbcontext data)
        {
            dbcontext = data;
        }

        public void Create(Class myClass)
        {
            dbcontext.Add(myClass);
            dbcontext.SaveChanges();
        }
    }
}

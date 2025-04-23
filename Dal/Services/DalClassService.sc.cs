using Dal.Api;
using Dal.Models;

namespace Dal.Services
{
    public class DalClassService : IDallClass
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

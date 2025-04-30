using Dal.Api;
using Dal.Models;

namespace Dal.Services
{
    public class DalMarkService : IDalMarks
    {
        readonly dbcontext dbcontext;
        public DalMarkService(dbcontext data)
        {
            dbcontext = data;
        }
        public void Create(MarksForStudent item)
        {
            dbcontext.MarksForStudents.Add(item);
            dbcontext.SaveChanges();
        }

        public int Update(MarksForStudent mark)
        {
            dbcontext.MarksForStudents.Update(mark);
            return dbcontext.SaveChanges();

        }
        public void Delete(MarksForStudent mark)
        {
            dbcontext.MarksForStudents.Remove(mark);
            dbcontext.SaveChanges();

        }
        public MarksForStudent? GetById(int id) => dbcontext.MarksForStudents.ToList().Find(x => x.Id == id);
    }
}

using Dal.Models;

namespace Dal.Api
{
    public interface IDalMarks
    {
        void Create(MarksForStudent item);
        int Update(MarksForStudent mark);
        void Delete(MarksForStudent mark);
        MarksForStudent? GetById(int id);


    }
}

using Dal.Models;

namespace Dal.Api
{
    public interface IDallClass
    {
        void Create(Class myClass);
        Class GetClassNameById(int id);
    }
}

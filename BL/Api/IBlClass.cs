using BL.Models;

namespace BL.Api
{
    public interface IBlClass
    {
        void Create(BlClass myClass);
        string GetClassNameById(int id);
    }
}

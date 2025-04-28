using Dal.Models;

namespace Dal.Api
{
    public interface IDalTeacher
    {
        List<Teacher> Get();
        void Create(Teacher item);
        Teacher? GetById(int id);
        void Delete(Teacher item);
        void Update(Teacher item);

        List<Student> GetStudentsForEducationTeacher(int myClass);
    }
}

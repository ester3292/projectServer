using Dal.Models;

namespace Dal.Api
{
    public interface IDalStudent
    {
        List<Student> Get();
        void Create(Student item);
        public List<MarksForStudent> GetMarks(int id);
        public Student? GetById(int id);
        public Student? GetByFullName(string firstName, string lastName);
        public void Delete(Student student);
        public void Update(Student student);


    }
}
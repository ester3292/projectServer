using Dal.Api;
using Dal.Models;

namespace Dal.Services
{
    public class DalStudentService : IDalStudent
    {
        readonly dbcontext dbcontext;
        public DalStudentService(dbcontext data)
        {
            dbcontext = data;
        }
        public void Create(Student item)
        {
            dbcontext.Students.Add(item);
            dbcontext.SaveChanges();
        }

        public List<Student> Get()
        {
            return dbcontext.Students.ToList();
        }
        /// <summary>
        /// קבלת ציונים ע"פ ת.ז. של התלמידה
        /// </summary>
        /// <param name="id">ת.ז. של התלמידה</param>
        /// <returns>ציונים</returns>
        public List<MarksForStudent> GetMarks(int id)
        {
            var x = dbcontext.MarksForStudents.ToList();
            var y = x.FindAll(x => x.StudentId == id);
            return y;
        }
        public Student? GetById(int id) => dbcontext.Students.ToList().Find(x => x.Id == id);
        public Student? GetByFullName(string firstName, string lastName) => dbcontext.Students.ToList().Find(x => x.FirstName == firstName && x.LastName == lastName);


        public void Delete(Student student)
        {
            dbcontext.Students.Remove(student);
            dbcontext.SaveChanges();

        }
        public void Update(Student student)
        {
            dbcontext.Students.Update(student);
            dbcontext.SaveChanges();

        }
    }
}

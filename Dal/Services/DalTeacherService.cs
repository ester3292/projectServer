using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalTeacherService:IDalTeacher
    {
        dbcontext dbcontext;
        public DalTeacherService(dbcontext data)
        {
            dbcontext = data;
        }
        /// <summary>
        /// כדי ליצור מורה חדש במאגר הנתונים
        /// </summary>
        /// <param name="item">מוסיפים את המורה </param>
        public void Create(Teacher item)
        {
            dbcontext.Teachers.Add(item);

            dbcontext.SaveChanges();
        }
        /// <summary>
        /// get מורות
        /// </summary>
        /// <returns>מחזירים את המורות</returns>
        public List<Teacher> Get()
        {
            return dbcontext.Teachers.ToList();
        }
        public Teacher GetById(int id)=>dbcontext.Teachers.ToList().Find(x => x.Id == id);
       
        /// <summary>
        ///  עבור הכיתה של המורה נחזיר את התלמידות שלה
        /// </summary>
        /// <param name="id">כיתה של המורה</param>
        /// <returns>תלמידות של המורה המבקשת</returns>
        public List<Student> GetStudentsForEducationTeacher(int myClass)
        {
           List<Student> ls = dbcontext.Students.ToList();
           ls=ls.FindAll(x=>x.Class==myClass).ToList();
            return ls;  
        }
        public void Delete(Teacher item)
        {
            dbcontext.Teachers.Remove(item);
            dbcontext.SaveChanges();

        }
        public void Update(Teacher item)
        {
            dbcontext.Teachers.Update(item);
            dbcontext.SaveChanges();

        }
    }
}

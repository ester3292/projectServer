using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service
{
    public class BlTeacherService : IBlTeacher
    {
        IDal dal;
        public BlTeacherService(IDal dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// יצירת מורה
        /// </summary>
        /// <param name="teacher"></param>
        public List<BlTeacher> Create(BlTeacher teacher)
        {
            Teacher p = new Teacher()
            {
                Id = teacher.Id,
                FirstName = teacher.FirstName,
                LastName = teacher.LastName,
                Email = teacher.Email,
                Phone = teacher.Phone,
                Educator = teacher.Educator
            };
            dal.Teachers.Create(p);
            return Get();
        }
        public List<BlTeacher> Update(BlTeacher teacher)
        {
            var p = dal.Teachers.GetById(teacher.Id);
            p.Phone = teacher.Phone;
            p.FirstName = teacher.FirstName;
            p.LastName = teacher.LastName;  
            p.Email = teacher.Email;
            p.Educator = teacher.Educator;
            dal.Teachers.Update(p);
            return Get();

        }
        public List<BlTeacher> Delete(BlTeacher teacher)
        {
            var t= dal.Teachers.GetById(teacher.Id);
            dal.Teachers.Delete(t);
            return Get();
        }
        /// <summary>
        /// החזרת המורות
        /// </summary>
        /// <returns>רשימת מורות</returns>
        public List<BlTeacher> Get()
        {
            var pList = dal.Teachers.Get();
            List<BlTeacher> list = new();
            pList.ForEach(p => list.Add(new BlTeacher()
            { Id = p.Id, FirstName = p.FirstName ?? "", LastName = p.LastName ?? "", Email = p.Email ?? "", Phone = p.Phone ?? "", Educator = p.Educator}));
            return list;
        }
        public BlTeacher GetById(int id)
        {
            var p=dal.Teachers.GetById(id);
            if( p != null) { 
            BlTeacher t2 = new BlTeacher()
            { Id = p.Id, FirstName = p.FirstName ?? "", LastName = p.LastName ?? "", Email = p.Email ?? "", Phone = p.Phone ?? "", Educator = p.Educator };
                return t2;
            }
            return null;   
        }

        /// <summary>
        /// פונקציה למציאת התלמידות שבכיתה של המורה המבקשת
        /// </summary>
        /// <param name="myClass">מקבל קוד כיתה </param>
        /// <returns></returns>
        public List<BlStudent> GetStudentsForEducationTeacher(int myClass)
        {          
            var pList = dal.Teachers.GetStudentsForEducationTeacher(myClass);
            List<BlStudent> list = new();
            pList.ForEach(p => list.Add(new BlStudent()
            { Id = p.Id, FirstName = p.FirstName ?? ""  , LastName = p.LastName ?? "", Phone = p.Phone ?? ""     ,Class = p.Class ?? 1 }));
            return list;

        }

    }
}

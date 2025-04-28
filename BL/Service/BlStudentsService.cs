using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;

namespace BL.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class BlStudentService : IBlStudent
    {
        IDal dal;
        public BlStudentService(IDal dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// הוספת תלמיד
        /// </summary>
        /// <param name="item"></param>
        public BlStudent Create(BlStudent item)
        {
            Student p = new Student()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Phone = item.Phone,
                Class = item.Class
            };
            dal.Students.Create(p);
            return item;
        }
        /// <summary>
        /// get לתלמידים
        /// </summary>
        /// <returns>List  של התלמידים</returns>
        public List<BlStudent> Get()
        {
            var pList = dal.Students.Get();
            List<BlStudent> list = new();
            pList.ForEach(p => list.Add(new BlStudent()
            { Id = p.Id, FirstName = p.FirstName ?? "", LastName = p.LastName ?? "", Phone = p.Phone ?? "", Class = p.Class ?? 0, MarksForStudents = GetMarks(p.Id) }));
            return list;
        }
        /// <summary>
        /// פונקציה פרטית הממלאת את מערך ציוני התלמיד מתוך טבלת הציונים
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private List<BlMarks> GetMarks(int id)
        {
            var pList = dal.Students.GetMarks(id);
            List<BlMarks> list = new();
            pList.ForEach(p => list.Add(new BlMarks()
            { Id = p.Id, StudentId = p.StudentId, Subject = p.Subject ?? "", Mark = p.Mark, Notes = p.Notes ?? "", TeacherId = p.TeacherId ?? 0, HalfA = p.HalfA ?? 0 }));
            return list;
        }
        /// <summary>
        /// פונקציה לקבלת ציון תלמיד במקצוע מסוים בקבלת מ.ז. ושם מקצוע
        /// אם עדיין אין כזה ציון מחזיר 0
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        private BlMarks GetMarkForStudentInSubject(int id, string subject)
        {
            List<BlMarks> list = GetMarks(id);
            BlMarks? blMarks = list.Find(p => p.Subject == subject);
            return blMarks;
        }
        /// <summary>
        /// פונקציה לקבלת ציון תלמיד במקצוע מסוים בקבלת מ.ז. שם מקצוע ומחצית
        /// אם עדיין אין כזה ציון מחזיר 0
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        private BlMarks? GetMarkForStudentInSubjectInHalf(int id, string subject, int halfA)
        {
            List<BlMarks> list = GetMarks(id);
            BlMarks? blMarks = list.Find(p => p.Subject == subject && p.HalfA == halfA);
            return blMarks;
        }
        /// <summary>
        /// הפונקציה מחזירה בהנתן מקצוע וכיתה 
        /// את רשימת ציוני תלמידות הכיתה המבוקשת במקצוע הרצוי
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="myClass"></param>
        /// <returns>dic  תלמידה וציון</returns>
        public List<BlStudentAndMark> GetMarksInSubject(string subject, int myClass)
        {
            List<BlStudentAndMark> lst = new();
            List<BlStudent> list = Get();
            list.ForEach(s =>
            {
                if (s.Class == myClass)
                {
                    BlMarks mark = GetMarkForStudentInSubject(s.Id, subject);
                    BlStudentAndMark l = new BlStudentAndMark()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Phone = s.Phone,
                        Class = s.Class,
                        MarksForStudent = mark
                    };
                    lst.Add(l);
                }
            });
            return lst;
        }
        /// <summary>
        /// הפונקציה מחזירה בהנתן מקצוע כיתה ומחצית  
        /// את רשימת ציוני תלמידות הכיתה המבוקשת במקצוע הרצוי באותה מחצית
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="myClass"></param>
        /// <returns>dic  תלמידה וציון</returns>
        public List<BlStudentAndMark> GetMarksInSubjectInHalf(string subject, int myClass, int HalfA)
        {
            List<BlStudentAndMark> lst = new();
            List<BlStudent> list = Get();
            list.ForEach(s =>
            {
                if (s.Class == myClass)
                {
                    BlMarks? mark = GetMarkForStudentInSubjectInHalf(s.Id, subject, HalfA);
                    BlStudentAndMark l = new BlStudentAndMark()
                    {
                        Id = s.Id,
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                        Phone = s.Phone,
                        Class = s.Class,
                        MarksForStudent = mark
                    };
                    lst.Add(l);
                }
            });
            return lst;
        }
        public List<string> GetAllSubjectsForClass(int myClass)
        {
            List<BlStudent> s = Get();
            List<String> lst = new();

            foreach (BlStudent student in s)
            {
                if (student.MarksForStudents != null && student.Class == myClass)
                {
                    foreach (BlMarks mark in student.MarksForStudents)
                    {
                        lst.Add(mark.Subject);
                    }
                }
            }
            List<string> k = lst.Distinct().ToList();
            return k;
        }
        public BlStudentAchivment getFullAchivmentForStudentById(int id)
        {
            BlStudent? s = GetById(id);
            BlStudentAchivment studentAchivment = getFullAchivmentForStudent(s);
            return studentAchivment;
        }
        public BlStudentAchivment getFullAchivmentForStudentByFullName(string firstName, string lastName)
        {
            BlStudent? s = GetByFullName(firstName, lastName);
            BlStudentAchivment studentAchivment = getFullAchivmentForStudent(s);
            return studentAchivment;
        }
        public BlStudentAchivment getFullAchivmentForStudent(BlStudent s)
        {
            BlStudentAchivment studentAchivmente = new BlStudentAchivment();
          
            studentAchivmente.Id = s.Id;    
            studentAchivmente.FirstName=s.FirstName;
            studentAchivmente.LastName=s.LastName;  
            studentAchivmente.Phone= s.Phone;
            studentAchivmente.Class = dal.Class.GetClassNameById(s.Class).Name;

            List<string> subs = GetAllSubjectsForClass(s.Class);
            foreach (string sub in subs)
            {
                BlMarks? bA = GetMarkForStudentInSubjectInHalf(s.Id, sub, 0);
                BlMarks? bB = GetMarkForStudentInSubjectInHalf(s.Id, sub, 1);
                int avg = 0;
                if (bA != null && bB != null)
                    avg = (bA.Mark + bB.Mark) / 2;
                else if (bB != null)
                    avg = bB.Mark;
                else if (bA != null)
                    avg = bA.Mark;
                BlCompleteMark blCompleteMark = new BlCompleteMark()
                {
                    Subject = sub,
                    MarkA = bA,
                    MarkB = bB,
                    Avg = avg
                };
                studentAchivmente.CompleteMark.Add(blCompleteMark);
            }
            return studentAchivmente;

        }

        public BlStudent? GetById(int id)
        {
            var p = dal.Students.GetById(id);
            if (p != null)
            {
                BlStudent t2 = new BlStudent()
                { Id = p.Id, FirstName = p.FirstName ?? "", LastName = p.LastName ?? "", Class = p.Class ?? 0, Phone = p.Phone ?? "", MarksForStudents = GetMarks(p.Id) };
                return t2;
            }
            return null;
        }
        public BlStudent? GetByFullName(string firstName, string lastName)
        {
            var p = dal.Students.GetByFullName(firstName, lastName);
            if (p != null)
            {
                BlStudent t2 = new BlStudent()
                { Id = p.Id, FirstName = p.FirstName ?? "", LastName = p.LastName ?? "", Class = p.Class ?? 0, Phone = p.Phone ?? "", MarksForStudents = GetMarks(p.Id) };
                return t2;
            }
            return null;
        }
        /// <summary>
        /// מחיקת תלמידה
        /// </summary>
        /// <param name="student"></param>
        public void Delete(BlStudent student)
        {
            var m = dal.Students.GetById(student.Id);
            List<BlMarks> marks = GetMarks(student.Id);
            if (marks != null)
            {
                foreach (var item in marks)
                {
                    BlManager blm = new BlManager();
                    blm.Marks.Delete(item);

                }
            }
            dal.Students.Delete(m);
        }
        /// <summary>
        ///   עדכון תלמידה
        /// </summary>
        /// <param name="student"></param>
        public void Update(BlStudent student)
        {
            var m = dal.Students.GetById(student.Id);
            m.Id = student.Id;
            m.FirstName = student.FirstName;
            m.LastName = student.LastName;
            m.Phone = student.Phone;
            m.Class = student.Class;
            // m.MarksForStudents = (ICollection<MarksForStudent>)GetMarks(student.Id);
            dal.Students.Update(m);
        }
    }
}

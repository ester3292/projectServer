using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlStudent
    {
        List<BlStudent> Get();
        List<BlStudent> Create(BlStudent student);
        public List<BlStudentAndMark> GetMarksInSubject(string subject, int myClass);
        public List<BlStudentAndMark> GetMarksInSubjectInHalf(string subject, int myClass, int HalfA);
        public List<String> GetAllSubjectsForClass(int myClass);
        public BlStudentAchivment? GetFullAchivmentForStudentById(int id);
        public BlStudentAchivment? GetFullAchivmentForStudentByFullName(string firstName, string lastName);

        public BlStudent? GetById(int id);
        public BlStudent? GetByFullName(string firstName, string lastName);
        public void Delete(BlStudent student);
        public void Update(BlStudent student);

    }
}

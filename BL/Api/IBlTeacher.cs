using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlTeacher
    {
        List<BlTeacher> Get();
        void Create(BlTeacher teacher);
         BlTeacher GetById(int id);
        void Delete(BlTeacher teacher);
        void Update(BlTeacher teacher);
        List<BlStudent> GetStudentsForEducationTeacher(int myClass);

    }
}

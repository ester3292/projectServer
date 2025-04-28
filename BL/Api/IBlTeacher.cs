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
        List<BlTeacher> Create(BlTeacher teacher);
         BlTeacher GetById(int id);
        List<BlTeacher> Delete(BlTeacher teacher);
        List<BlTeacher> Update(BlTeacher teacher);
        List<BlStudent> GetStudentsForEducationTeacher(int myClass);

    }
}

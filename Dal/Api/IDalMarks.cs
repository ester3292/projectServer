using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalMarks
    {
        void Create(MarksForStudent item);
        int Update(MarksForStudent mark);
        void Delete(MarksForStudent mark);
        MarksForStudent GetById(int id);


    }
}

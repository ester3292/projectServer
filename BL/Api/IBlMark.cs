using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlMark
    {
        void Create(BlMarks mark);
        int Update(BlMarks mark);
        BlMarks? GetById(int id);
        void Delete(BlMarks mark);
    }
}

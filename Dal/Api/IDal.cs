using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDal
    {
        //cvbcxd
        public IDalStudent Students { get; }
        public IDalTeacher Teachers { get; }
        public IDalMarks Marks { get; }
        public IDallClass Class { get; }
    }
}

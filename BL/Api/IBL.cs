using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBL
    {
        public IBlStudent Students { get; }
        public IBlTeacher Teachers { get; }
        public IBlMark Marks { get; }
        public IBlClass Classes { get; }
    }
}

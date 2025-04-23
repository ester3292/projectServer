using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlCompleteMark
    {
        public string Subject { get; set; } =string.Empty;
        public BlMarks MarkA { get; set; }=new BlMarks();   
        public BlMarks MarkB { get; set; }= new BlMarks();
        public int Avg { get; set; }
    }
}

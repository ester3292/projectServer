using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlStudentAchivment
    {
        public int Id { get; set; }
        public string FirstName { get; set; }=string.Empty; 
        public string LastName { get; set; } = string.Empty;    
        public string Phone { get; set; } = string.Empty;   
        public int Class { get; set; }
       public List<BlCompleteMark> CompleteMark { get; set; }=new List<BlCompleteMark>();   
    }
}

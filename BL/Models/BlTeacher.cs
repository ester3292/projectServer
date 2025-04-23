using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlTeacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";  
        public string Email { get; set; } = "";
        public string Phone { get; set; } = ""; 
        public bool Educator { get; set; }
       


    }
}

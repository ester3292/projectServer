


using System.ComponentModel.DataAnnotations.Schema;

namespace BL.Models
{
    public class BlMarks
    {

        public int Id { get; init; } 
        public int StudentId { get; set; }    
        public string Subject { get; set; } = "";
        public int Mark { get; set; }   
        public string Notes { get; set; } = "";
        public int TeacherId { get; set; }
        public int HalfA { get; set; }

    }
}

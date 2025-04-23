namespace BL.Models
{
    public class BlStudent
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Phone { get; set; } = "";
        public int Class { get; set; }
        public virtual List<BlMarks>? MarksForStudents { get; set; }
    }
}


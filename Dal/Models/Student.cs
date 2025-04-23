using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Phone { get; set; }

    public int? Class { get; set; }

    public virtual Class? ClassNavigation { get; set; }

    public virtual ICollection<MarksForStudent> MarksForStudents { get; set; } = new List<MarksForStudent>();
}

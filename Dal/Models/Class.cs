using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Class
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}

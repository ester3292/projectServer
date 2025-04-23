using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class MarksForStudent
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string Subject { get; set; } = null!;

    public int Mark { get; set; }

    public string? Notes { get; set; }

    public int? TeacherId { get; set; }

    public int? HalfA { get; set; }

    public virtual Student Student { get; set; } = null!;

    public virtual Teacher? Teacher { get; set; }
}

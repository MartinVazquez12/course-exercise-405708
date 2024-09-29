using System;
using System.Collections.Generic;

namespace CourseRoleWebAPI.Models;

public partial class CourseType
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}

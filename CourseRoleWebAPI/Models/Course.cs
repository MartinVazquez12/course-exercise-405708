﻿using System;
using System.Collections.Generic;

namespace CourseRoleWebAPI.Models;

public partial class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid CourseTypeId { get; set; }

    public bool Active { get; set; }

    public bool Visible { get; set; }

    public virtual CourseType CourseType { get; set; } = null!;
}

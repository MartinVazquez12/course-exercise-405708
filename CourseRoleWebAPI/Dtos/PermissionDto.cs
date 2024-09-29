namespace CourseRoleWebAPI.Dtos
{
    public class PermissionDto
    {
        public Guid Id { get; set; }

        public string Module { get; set; } = null!;

        public string Feature { get; set; } = null!;

        public string? Description { get; set; }

        public bool Enabled { get; set; }
    }
}

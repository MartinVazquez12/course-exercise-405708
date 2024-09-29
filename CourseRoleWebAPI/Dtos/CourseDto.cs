using System.ComponentModel.DataAnnotations;

namespace CourseRoleWebAPI.Dtos
{
    public class CourseDto
    {
        public Guid id_course { get; set; }

        [Required]
        [StringLength(100)]
        public string namedto { get; set; }

        public string? descriptiondto { get; set; }

        [Required]
        public Guid type { get; set; }
    }
}

using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CourseRoleWebAPI.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        private readonly CoursesRolesContext _context;

        public CourseRepo(CoursesRolesContext coursesRolesContext)
        {
            _context = coursesRolesContext;
        }

        public async Task<Course> AddCourse(Course course)
        {
            try
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return course;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error: " + ex.InnerException?.Message);
                Console.WriteLine("Detalles: " + ex.InnerException?.ToString());
                throw;
            }
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(Guid courseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(x =>
                                                x.Id == courseId);
            if (course == null) 
            {
                throw new Exception();
            }
            return course;
        }

        public async Task<Course> UpdateCourse(CourseDto courseDto)
        {
            var entity = await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseDto.id_course);

            if (entity == null)
            {
                // Manejar el caso cuando el curso no se encuentra
                return null;
            }

            entity.Id = courseDto.id_course;
            entity.Name = courseDto.namedto;
            entity.Description = courseDto.descriptiondto;
            entity.CourseTypeId = courseDto.type;
            entity.Active = true;
            entity.Visible = true;

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}

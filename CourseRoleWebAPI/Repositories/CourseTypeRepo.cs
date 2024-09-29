using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CourseRoleWebAPI.Repositories
{
    public class CourseTypeRepo : ICourseTypeRepository
    {
        private readonly CoursesRolesContext _context;

        public CourseTypeRepo(CoursesRolesContext coursesRolesContext)
        {
            _context = coursesRolesContext;
        }

        public async Task<List<CourseType>> GetAllCourseTypes()
        {
            return await _context.CourseTypes.ToListAsync();
        }
    }
}

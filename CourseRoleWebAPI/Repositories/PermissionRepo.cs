using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace CourseRoleWebAPI.Repositories
{
    public class PermissionRepo : IPermissionRepository
    {
        private readonly CoursesRolesContext _context;

        public PermissionRepo(CoursesRolesContext coursesRolesContext)
        {
            _context = coursesRolesContext;
        }

        public async Task<List<Permission>> GetAllPermis()
        {
            return await _context.Permissions.ToListAsync();
        }
    }
}

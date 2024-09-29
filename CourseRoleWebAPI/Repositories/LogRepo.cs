using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;

namespace CourseRoleWebAPI.Repositories
{
    public class LogRepo : ILogRepository
    {

        private readonly CoursesRolesContext _context;

        public LogRepo(CoursesRolesContext coursesRolesContext)
        {
            _context = coursesRolesContext;
        }

        public async Task<Log> AddLog(Log log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();
            return log;
        }
    }
}

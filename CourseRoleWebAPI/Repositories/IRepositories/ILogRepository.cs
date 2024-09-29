using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;

namespace CourseRoleWebAPI.Repositories.IRepositories
{
    public interface ILogRepository
    {
        Task<Log> AddLog(Log log);
    }
}

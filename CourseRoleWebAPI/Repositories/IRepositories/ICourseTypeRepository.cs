using CourseRoleWebAPI.Models;

namespace CourseRoleWebAPI.Repositories.IRepositories
{
    public interface ICourseTypeRepository
    {
        Task<List<CourseType>> GetAllCourseTypes();
    }
}

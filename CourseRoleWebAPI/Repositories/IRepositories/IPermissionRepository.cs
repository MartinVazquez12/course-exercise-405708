using CourseRoleWebAPI.Models;

namespace CourseRoleWebAPI.Repositories.IRepositories
{
    public interface IPermissionRepository
    {
        Task<List<Permission>> GetAllPermis();
    }
}

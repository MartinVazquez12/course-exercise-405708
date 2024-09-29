using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;

namespace CourseRoleWebAPI.Services.IServices
{
    public interface IPermissionService
    {
        Task<ApiResponseDto<List<PermissionDto>>> GetPermissions();
    }
}

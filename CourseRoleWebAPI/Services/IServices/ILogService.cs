using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;

namespace CourseRoleWebAPI.Services.IServices
{
    public interface ILogService
    {
        Task<ApiResponseDto<LogDto>> AddLog(LogDto log);
    }
}

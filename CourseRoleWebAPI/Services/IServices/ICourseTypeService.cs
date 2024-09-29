using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;

namespace CourseRoleWebAPI.Services.IServices
{
    public interface ICourseTypeService
    {
        Task<ApiResponseDto<List<CourseTypeDto>>> GetCourses();
    }
}

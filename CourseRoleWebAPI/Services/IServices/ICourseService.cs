using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;

namespace CourseRoleWebAPI.Services.IServices
{
    public interface ICourseService
    {
        Task<ApiResponseDto<CourseDto>> AddCourse(CourseDto courseDto);
        Task<ApiResponseDto<CourseDto>> GetCourseById(Guid courseId);
        Task<ApiResponseDto<List<CourseDto>>> GetAll();
        Task<ApiResponseDto<CourseDto>> UpdateCourse(CourseDto courseDto);
    }
}

using AutoMapper;
using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using CourseRoleWebAPI.Services.IServices;
using System.Net;

namespace CourseRoleWebAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<CourseDto>> AddCourse(CourseDto courseDto)
        {
            var response = new ApiResponseDto<CourseDto>();

            courseDto.id_course = Guid.NewGuid();
            var courseToMap = _mapper.Map<Course>(courseDto);
            
            var courseAdd = await _repository.AddCourse(courseToMap);
            if (courseAdd != null)
            {
                var courseDtoAdd = _mapper.Map<CourseDto>(courseAdd);
                response.Success = true;
                response.Data = courseDtoAdd;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se pudo agregar", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<List<CourseDto>>> GetAll()
        {
            ApiResponseDto<List<CourseDto>> response = new ApiResponseDto<List<CourseDto>>();

            List<Course> listCourses = await _repository.GetAllCourses();

            if (listCourses == null && listCourses.Count == 0)
            {
                response.SetError("No existe", HttpStatusCode.NotFound);
            }
            else
            {
                var coursesDto = _mapper.Map<List<CourseDto>>(listCourses);

                for (int i = 0; i < listCourses.Count; i++)
                {
                    coursesDto[i].id_course = listCourses[i].Id;
                }
                response.Success = true;
                response.ErrorMessage = "Lista de Courses";
                response.Data = coursesDto;
                response.StatusCode = HttpStatusCode.OK;
            }
            return response;
        }

        public async Task<ApiResponseDto<CourseDto>> GetCourseById(Guid courseId)
        {
            var response = new ApiResponseDto<CourseDto>();
            var course = await _repository.GetCourseById(courseId);
            if (course != null)
            {
                var courseDto = _mapper.Map<CourseDto>(course);
                response.Data = courseDto;
                response.Success = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se encontro curso con el id", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }

        public async Task<ApiResponseDto<CourseDto>> UpdateCourse(CourseDto courseDto)
        {
            var response = new ApiResponseDto<CourseDto>();

            var courseUpdate = await _repository.UpdateCourse(courseDto);

            if (courseUpdate != null)
            {
                var courseUpdatedDto = _mapper.Map<CourseDto>(courseUpdate);
                courseUpdatedDto.id_course = courseUpdate.Id;
                courseUpdatedDto.type = courseUpdate.CourseTypeId;
                courseUpdatedDto.namedto = courseUpdate.Name;
                courseUpdatedDto.descriptiondto = courseUpdate.Description;

                response.Data = courseUpdatedDto;
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se pudo modificar el curso", HttpStatusCode.InternalServerError);
            }
            return response;
        }

    }
}

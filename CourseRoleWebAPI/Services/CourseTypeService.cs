using AutoMapper;
using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using CourseRoleWebAPI.Services.IServices;

namespace CourseRoleWebAPI.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private readonly ICourseTypeRepository _repository;
        private readonly IMapper _mapper;

        public CourseTypeService(ICourseTypeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<ApiResponseDto<List<CourseTypeDto>>> GetCourses()
        {
            ApiResponseDto<List<CourseTypeDto>> response = new ApiResponseDto<List<CourseTypeDto>>();
            
            List<CourseType> lstCourseTypes = await _repository.GetAllCourseTypes();

            if (lstCourseTypes == null || lstCourseTypes.Count == 0) {
                response.SetError("No existen types", System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                var coursesTypesDto = _mapper.Map<List<CourseTypeDto>>(lstCourseTypes);
                for (int i = 0; i < lstCourseTypes.Count; i++)
                {
                    coursesTypesDto[i].nametype = lstCourseTypes[i].Name;
                }
                response.Success = true;
                response.ErrorMessage = "Lista de tipos de curso";
                response.Data = coursesTypesDto;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return response;
        }
    }
}

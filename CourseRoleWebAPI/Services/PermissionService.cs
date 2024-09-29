using AutoMapper;
using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using CourseRoleWebAPI.Services.IServices;

namespace CourseRoleWebAPI.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _repository;
        private readonly IMapper _mapper;

        public PermissionService(IPermissionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<List<PermissionDto>>> GetPermissions()
        {
            ApiResponseDto<List<PermissionDto>> response = new ApiResponseDto<List<PermissionDto>>();

            List<Permission> lstPermiss = await _repository.GetAllPermis();

            if (lstPermiss == null || lstPermiss.Count == 0)
            {
                response.SetError("No existen types", System.Net.HttpStatusCode.NotFound);
            }
            else
            {
                var permisDto = _mapper.Map<List<PermissionDto>>(lstPermiss);
                for (int i = 0; i < lstPermiss.Count; i++)
                {
                    permisDto[i].Module = lstPermiss[i].Module;
                }
                response.Success = true;
                response.ErrorMessage = "Lista de permis";
                response.Data = permisDto;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            return response;
        }
    }
}

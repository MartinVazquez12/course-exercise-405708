using AutoMapper;
using CourseRoleWebAPI.ApiResponse;
using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Repositories.IRepositories;
using CourseRoleWebAPI.Services.IServices;

namespace CourseRoleWebAPI.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repository;
        private readonly IMapper _mapper;

        public LogService(ILogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ApiResponseDto<LogDto>> AddLog(LogDto logDto)
        {
            var response = new ApiResponseDto<LogDto>();

            logDto.datedto = DateTime.Now;

            var logToMap = _mapper.Map<Log>(logDto);
            logToMap.Id = Guid.NewGuid();

            var logAdd = await _repository.AddLog(logToMap);
            if (logAdd != null) {
                var logDtoAdd = _mapper.Map<LogDto>(logAdd);
                response.Success = true;
                response.Data = logDtoAdd;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.SetError("No se pudo agregar", System.Net.HttpStatusCode.InternalServerError);
            }
            return response;
        }
    }
}

using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CourseRoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController:ControllerBase
    {
        private readonly ILogService _service;

        public LogController(ILogService service)
        {
            _service = service;
        }

        [HttpPost("/Log/PostLog")]
        public async Task<IActionResult> AddLog([FromBody] LogDto logDto)
        {
            try
            {
                var response = await _service.AddLog(logDto);

                if (response.Success)
                {
                    return Ok(response.Data);
                }
                else
                {
                    return BadRequest(response.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

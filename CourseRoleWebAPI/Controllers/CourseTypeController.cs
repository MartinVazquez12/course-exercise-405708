using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CourseRoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTypeController:ControllerBase
    {
        private readonly ICourseTypeService _service;

        public CourseTypeController(ICourseTypeService service)
        {
            _service = service;
        }

        [HttpGet("/GetCourseType")]
        public async Task<ActionResult<List<Permission>>> Get()
        {
            return Ok(await _service.GetCourses());
        }
    }
}

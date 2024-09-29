using CourseRoleWebAPI.Models;
using CourseRoleWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CourseRoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _service;

        public PermissionController(IPermissionService service)
        {
            _service = service;
        }

        [HttpGet("/GetPermis")]
        public async Task<ActionResult<List<Permission>>> Get()
        {
            return Ok(await _service.GetPermissions());
        }

    }
}

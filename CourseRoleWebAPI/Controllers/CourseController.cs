using CourseRoleWebAPI.Dtos;
using CourseRoleWebAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CourseRoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService service)
        {
            _service = service;
        }


        [HttpPost("/Course/PostCourse")]
        public async Task<IActionResult> AddCourse([FromBody] CourseDto courseDto)
        {
            try
            {
                var response = await _service.AddCourse(courseDto);

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

        [HttpGet("/Course/GetCourseById/{id}")]
        public async Task<IActionResult> GetCourseById(Guid id)
        {
            var result = await _service.GetCourseById(id);

            if (!result.Success)
            {
                return StatusCode((int)result.StatusCode, result.Data);
            }
            return Ok(result.Data);
        }

        [HttpGet("/Course/GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }


        [HttpPut("/Course/UpdateCourse")]
        public async Task<IActionResult> UpdateCourse([FromBody] CourseDto courseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _service.UpdateCourse(courseDto);
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

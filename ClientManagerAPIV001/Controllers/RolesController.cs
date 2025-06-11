using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerAPIV001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRolesService rolesService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string cd = User.Claims.FirstOrDefault(c => c.Type == "UserCD")?.Value ?? string.Empty;
            if (cd == null)
            {
                return BadRequest("User is null. May Token invalid.");
            }
            AppRes<RoleRes> result = rolesService.GetByCD(cd);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}

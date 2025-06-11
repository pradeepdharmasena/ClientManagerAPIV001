using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Services;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerAPIV001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthanticationController(IAuthanticationService authanticationService) : ControllerBase
    {
        [HttpPost]
        public IActionResult GetToken(UserLoginReq userLoginReqDTO)
        {
            var response = authanticationService.Login(userLoginReqDTO);
            if (response.Error != null && response.Error.IsError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

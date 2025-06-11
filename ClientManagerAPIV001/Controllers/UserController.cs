using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagerAPIV001.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string? cd = User.Claims.FirstOrDefault(c => c.Type == "UserCD")?.Value;
            if (cd == null)
            {
                return BadRequest("User is null. May Token invalid.");
            }
            AppRes<UserRes> result = userService.GetByCD(Guid.Parse(cd));
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(UserRegisterReq userRegisterReqDTO)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterReqDTO.Password);
            userRegisterReqDTO.Password = passwordHash;
            AppRes<UserRes> result = userService.Create(userRegisterReqDTO);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update(UserUpdateReq userUpdateReqDTO)
        {
            AppRes<UserRes> result = userService.Update(userUpdateReqDTO);
            if (result.Error != null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}

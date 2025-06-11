using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Repositories;
using ClientManagerAPIV001.Repository;
using ClientManagerAPIV001.Services.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ClientManagerAPIV001.Services
{
    public class AuthanticationService(IConfiguration configuration, IUserRepository userRepository) : IAuthanticationService
    {
        public AppRes<UserLoginRes> Login(UserLoginReq userLoginReqDTO)
        {
            User? user = userRepository.GetByEmail(userLoginReqDTO.Email);

            if (user == null)
            {
                return new AppRes<UserLoginRes>()
                {
                    Error = ErrorManager.GetObj(null, null)
                };
            }
            DateTime expierDateTime = DateTime.Now.AddHours(8);
            UserLoginRes loginResponseDTO = new UserLoginRes();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? string.Empty));
            Console.WriteLine($"Jwt:Key: {key}");
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserCD", user!.UserCD.ToString()),
                new Claim("Email", user!.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            JwtSecurityToken accessTokenObj = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: expierDateTime,
                signingCredentials: credentials);

            loginResponseDTO.AccessToken = new JwtSecurityTokenHandler().WriteToken(accessTokenObj);
            expierDateTime = expierDateTime.AddHours(16);

            JwtSecurityToken refreshTokenObj = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: expierDateTime,
                signingCredentials: credentials);

            loginResponseDTO.RefreshToken = new JwtSecurityTokenHandler().WriteToken(refreshTokenObj);
            return new AppRes<UserLoginRes>()
            {
                Results = loginResponseDTO
            };
        }
    }
}

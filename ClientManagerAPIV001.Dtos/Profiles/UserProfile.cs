using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Dtos.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserRes>();
            CreateMap<UserRegisterReq, User>();
        }
    }
}

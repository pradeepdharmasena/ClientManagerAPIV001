using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClientManagerAPIV001.Dtos.Requests.Role;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Dtos.Profiles
{
    public class RolesProfile : Profile
    {
        public RolesProfile() 
        {
            CreateMap<RoleCreateReq, Role>();
            CreateMap<Role, RoleRes>();
        }
    }
}

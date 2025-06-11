using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services
{
    public interface IAuthanticationService 
    {
        public AppRes<UserLoginRes> Login(UserLoginReq loginReqDTO);
    }
}

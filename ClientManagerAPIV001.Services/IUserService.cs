using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services
{
    public interface IUserService
    {
        public AppRes<UserRes> Create(UserRegisterReq userRegisterReqDTO);
        public AppRes<UserRes> Update(UserUpdateReq userUpdateReqDTO);
        public AppRes<UserRes> GetByCD(Guid cd);
        public AppRes<UserRes> GetByEmailAndPassword(UserLoginReq userLoginReqDTO);
        public AppRes<UserRes> SoftDelete(Guid cd);
        public AppRes<UserRes> Delete(UserLoginReq userLoginReqDTO);




    }
}
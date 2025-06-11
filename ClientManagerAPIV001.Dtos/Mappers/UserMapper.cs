using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;

namespace ClientManagerAPIV001.Dtos.Mappers
{
    public static class UserMapper
    {
        public static AppRes<UserRes> toUserRegisterRes(User user)
        {
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = new CustomErrorRes()
                    {
                        IsError = true,
                        ErrorCode = "GE000001",
                        Message = "User is null"
                    }
                };
            }
            return new AppRes<UserRes>()
            {
                Results = new UserRes()
                {
                    Email = user.Email,
                    UserCD = user.UserCD,
                    Status = user.Status,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ProfileImageURL = user.ProfileImageURL,
                    Roles = user.Roles,
                    RefreshToken = user.RefreshToken,
                    CreatedDateTime = user.CreatedDateTime,
                    IsDeleted = user.IsDeleted
                },
            };
            
        }

     //   public static User fromUserRegisterReq(UserRegisterReq userRegisterReq)
     //   {
    //        return new User()
   //         {
  //              Email = userRegisterReq.Email,
  //              FirstName = userRegisterReq.FirstName,
   //             LastName = userRegisterReq.LastName,

  //          };
  //      }
    }
}

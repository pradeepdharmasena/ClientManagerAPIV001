
using AutoMapper;
using ClientManagerAPIV001.Dtos.Requests.User;
using ClientManagerAPIV001.Dtos.Responses;
using ClientManagerAPIV001.Models;
using ClientManagerAPIV001.Repositories;
using ClientManagerAPIV001.Services.Utils;

namespace ClientManagerAPIV001.Services
{
    public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
    {
        public AppRes<UserRes> Create(UserRegisterReq userRegisterReqDTO)
        {
            User? user = mapper.Map<User>(userRegisterReqDTO);
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null,"Input parameters may incorrect. Unable to create User")
                };
            }
            user = userRepository.Create(user);
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to create User")
                };
            }
            return new AppRes<UserRes>() 
            {
                Results = mapper.Map<UserRes>(user)
            };

        }

        public AppRes<UserRes> GetByCD(Guid cd)
        {
            User? user = userRepository.GetByCD(cd);
            if (user == null) {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to find User")
                };
            }
            return new AppRes<UserRes>()
            {
                Results = mapper.Map<UserRes>(user)
            };

        }

        public AppRes<UserRes> GetByEmailAndPassword(UserLoginReq userLoginReqDTO)
        {
            User? user = userRepository.GetByEmail(userLoginReqDTO.Email);
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to find User")
                };
            }
            return new AppRes<UserRes>()
            {
                Results = mapper.Map<UserRes>(user)
            };
        }

        public AppRes<UserRes> SoftDelete(Guid cd)
        {
            User? user = userRepository.GetByCD(cd);
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to find User")
                };
            }
            user.IsDeleted = true;
            user = userRepository.Update(user);

            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to update User")
                };
            }
            return new AppRes<UserRes>()
            {
                Results = mapper.Map<UserRes>(user)
            };
        }

        public AppRes<UserRes> Delete(UserLoginReq userLoginReqDTO)
        {
            throw new NotImplementedException();
        }

        public AppRes<UserRes> Update(UserUpdateReq userUpdateReqDTO)
        {
            User? user = userRepository.GetByCD(userUpdateReqDTO.UserCD);

            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to find the User")
                };
            }
            if (userUpdateReqDTO.Status != null)
            {
                user.Status = (int)userUpdateReqDTO.Status;
            }
            if (userUpdateReqDTO.Password != null)
            {
                user.Password = userUpdateReqDTO.Password;
            }
            if (userUpdateReqDTO.Roles != null)
            {
                user.Roles = userUpdateReqDTO.Roles;
            }
            if (userUpdateReqDTO.FirstName != null)
            {
                user.FirstName = userUpdateReqDTO.FirstName;
            }
            if (userUpdateReqDTO.LastName != null)
            {
                user.LastName = userUpdateReqDTO.LastName;
            }
            if (userUpdateReqDTO.Email != null)
            {
                user.Email = userUpdateReqDTO.Email;
            }
            if (userUpdateReqDTO.ProfileImageURL != null)
            {
                user.ProfileImageURL = userUpdateReqDTO.ProfileImageURL;
            }

            user = userRepository.Update(user);
            if (user == null)
            {
                return new AppRes<UserRes>()
                {
                    Error = ErrorManager.GetObj(null, "Unable to update User")
                };
            }
            return new AppRes<UserRes>()
            {
                Results = mapper.Map<UserRes>(user)
            };
        }
    }
}

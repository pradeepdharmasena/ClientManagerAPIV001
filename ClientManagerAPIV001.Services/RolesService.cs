using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.Role;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services
{
    public class RolesService : IRolesService
    {
        public AppRes<RoleRes> Create(RoleCreateReq roleCreateReqDTO)
        {
            throw new NotImplementedException();
        }

        public AppRes<RoleRes> Delete(string cd)
        {
            throw new NotImplementedException();
        }

        public AppRes<RoleRes> GetByCD(string cd)
        {
            throw new NotImplementedException();
        }

        public AppRes<RoleRes> SoftDelete(string cd)
        {
            throw new NotImplementedException();
        }

        public AppRes<RoleRes> Update(RoleUpdateReq roleUpdateReqDTO)
        {
            throw new NotImplementedException();
        }
    }
}

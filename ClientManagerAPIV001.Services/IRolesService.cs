using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagerAPIV001.Dtos.Requests.Role;
using ClientManagerAPIV001.Dtos.Responses;

namespace ClientManagerAPIV001.Services
{
    public interface IRolesService
    {
        public AppRes<RoleRes> Create(RoleCreateReq roleCreateReqDTO);
        public AppRes<RoleRes> Update(RoleUpdateReq roleUpdateReqDTO);
        public AppRes<RoleRes> GetByCD(string cd);
        public AppRes<RoleRes> SoftDelete(string cd);
        public AppRes<RoleRes> Delete(string cd);

    }
}

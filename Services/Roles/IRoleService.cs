using Core.Models.Roles;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Roles
{
    public interface IRoleService
    {
        public IServiceResponse<RoleModel> GetRoleById(int userId, int roleGroupID, Int64 roleID);
        public IServiceResponse<RoleModel> GetRoleListByGroupId(int userId, int roleGroupID);
    }
}
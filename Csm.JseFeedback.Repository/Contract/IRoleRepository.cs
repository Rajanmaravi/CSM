using Csm.JseFeedback.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleModel>> SearchRoles();
        Task<string> AddRole(RoleDaoModel roleModel);
        Task<string> UpdateRole(RoleDaoModel roleModel);
        Task<string> DeleteRole(RoleDaoModel roleModel);
    }
}

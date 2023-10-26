using Csm.JseFeedback.Model;
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
        Task<string> AddRole(RoleModel roleModel);
        Task<string> UpdateRole(RoleModel roleModel);
        Task<string> DeleteRole(RoleModel roleModel);
    }
}

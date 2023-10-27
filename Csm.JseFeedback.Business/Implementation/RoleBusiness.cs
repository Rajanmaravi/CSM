using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class RoleBusiness:BaseBusiness,IRoleBusiness
    {
        private readonly IRoleRepository _roleRepository;
        public RoleBusiness(ILogger<BaseBusiness> logger,IRoleRepository roleRepository):base(logger)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> AddRole(RoleModel roleModel)
        {
            return await _roleRepository.AddRole(roleModel);
        }

        public async Task<string> DeleteRole(RoleModel roleModel)
        {
            return await _roleRepository.DeleteRole(roleModel);
        }

        public async Task<IEnumerable<RoleModel>> SearchRoles()
        {
            return await _roleRepository.SearchRoles();
        }

        public async Task<string> UpdateRole(RoleModel roleModel)
        {
            return await _roleRepository.UpdateRole(roleModel);
        }
    }
}

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
            _roleRepository = roleRepository??throw new ArgumentNullException(nameof(roleRepository));
        }

        public async Task<string> AddRole(RoleDaoModel roleModel)
        {
            try
            {
                return await _roleRepository.AddRole(roleModel);
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception in RoleBusiness.AddRole");
                throw;
            }
        }

        public async Task<string> DeleteRole(RoleDaoModel roleModel)
        {
            try { 
            return await _roleRepository.DeleteRole(roleModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in RoleBusiness.DeleteRole");
                throw;
            }
        }

        public async Task<IEnumerable<RoleModel>> SearchRoles()
        {
            try { 
            return await _roleRepository.SearchRoles();
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in RoleBusiness.SearchRoles");
                throw;
            }
        }

        public async Task<string> UpdateRole(RoleDaoModel roleModel)
        {
            try { 
            return await _roleRepository.UpdateRole(roleModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in RoleBusiness.UpdateRole");
                throw;
            }
        }
    }
}

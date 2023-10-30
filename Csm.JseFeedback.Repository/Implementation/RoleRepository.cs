using Csm.JseFeedback.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public class RoleRepository :BaseRepository, IRoleRepository
    {
        public RoleRepository(CsmDbContext dbContext, ILogger<RoleRepository> logger):base(dbContext,logger) { }

        public async Task<string> AddRole(RoleDaoModel roleModel)
        {
            try
            {
                var procedureName = "USP_Add_Role_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@RoleCode", roleModel.RoleCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@Description", roleModel.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", roleModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception RoleRepository.AddRole");
                throw;
            }
        }



        public async Task<string> DeleteRole(RoleDaoModel roleModel)
        {
            try
            {
                var procedureName = "USP_Delete_Role_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@RoleCode", roleModel.RoleCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@Description", roleModel.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", roleModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception RoleRepository.DeleteRole");
                throw;
            }
        }

        public async Task<IEnumerable<RoleModel>> SearchRoles()
        {
            try
            {
                var procedureName = "USP_Search_Role_Details";
                var parameters = new DynamicParameters();
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.Query<RoleModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception RoleRepository.SearchRoles");
                throw;
            }
        }

        public async Task<string> UpdateRole(RoleDaoModel roleModel)
        {
            try
            {
                var procedureName = "USP_Update_Role_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@RoleCode", roleModel.RoleCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@Description", roleModel.Description, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", roleModel.IsActive, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", roleModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception RoleRepository.UpdateRole");
                throw;
            }
        }
    }
}

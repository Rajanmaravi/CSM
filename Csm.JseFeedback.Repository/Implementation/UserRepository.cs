using Csm.JseFeedback.Model;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public class UserRepository :BaseRepository, IUserRepository
    {
        public UserRepository(CsmDbContext dbContext, ILogger<UserRepository> logger):base(dbContext,logger) { }
        public async Task<UserModel> ValidateUser(LoginModel loginModel)
        {
            try
            {
                var procedureName = "USP_ValidateUser";
                var parameters = new DynamicParameters();
                parameters.Add("@UserCode", loginModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@Password", loginModel.Password, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<UserModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.ValidateUser");
                throw;
            }

        }
    }
}

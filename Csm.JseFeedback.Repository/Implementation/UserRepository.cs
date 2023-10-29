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

        public async Task<string> AddUser(UserDaoModel userModel)
        {
            try
            {
                var procedureName = "USP_Add_User_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", userModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", userModel.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", userModel.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Password", userModel.Password, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", userModel.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", userModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.AddUser");
                throw;
            }
        }

        public async Task<string> ChangePassword(PasswordChangeModel passwordChangeModel)
        {
            try
            {
                var procedureName = "USP_Update_User_Password";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", passwordChangeModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@OldPassword", passwordChangeModel.OldPassword, DbType.String, ParameterDirection.Input);
                parameters.Add("@NewPassword", passwordChangeModel.NewPassword, DbType.String, ParameterDirection.Input);
                parameters.Add("@ConfirmPassword", passwordChangeModel.ConfirmPassword, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", passwordChangeModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.ChangePassword");
                throw;
            }
        }

        public async Task<string> DeleteUser(UserDaoModel userModel)
        {
            try
            {
                var procedureName = "USP_Delete_User_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", userModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                       parameters.Add("@LoggedInUser", userModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.DeleteUser");
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> SearchUser(UserSearchModel userSearch)
        {
            try
            {
                var procedureName = "USP_Search_User_Detail";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", userSearch.EmployeeCode, DbType.VarNumeric, ParameterDirection.Input);
                parameters.Add("@EmployeeName", userSearch.Name, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.Query<UserModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.SearchUser");
                throw;
            }
        }

        public async Task<string> UpdateRefreshToken(UserDaoModel userModel)
        {
            try
            {
                var procedureName = "USP_Update_User_AccessToken";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", userModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RefreshToken", userModel.RefreshToken, DbType.String, ParameterDirection.Input);
                parameters.Add("@RefreshTokenExpiresOn", userModel.RefreshTokenExpiresOn, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", userModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.UpdateRefreshToken");
                throw;
            }
        }

        public async Task<string> UpdateUser(UserDaoModel userModel)
        {
            try
            {
                var procedureName = "USP_Update_User_Detail";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", userModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", userModel.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", userModel.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", userModel.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", userModel.IsActive, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", userModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception UserRepository.UpdateUser");
                throw;
            }
        }

        public async Task<UserModel> ValidateUser(LoginModel loginModel)
        {
            try
            {
                var procedureName = "USP_Validate_User";
                var parameters = new DynamicParameters();
                parameters.Add("@UserCode", loginModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@Password", loginModel.Password, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<UserModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                    
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

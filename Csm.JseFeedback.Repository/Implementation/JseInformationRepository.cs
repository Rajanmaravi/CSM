using Csm.JseFeedback.Model;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Csm.JseFeedback.Repository
{
    public class JseInformationRepository : BaseRepository, IJseRepository
    {
        public JseInformationRepository(CsmDbContext dbContext, ILogger<JseInformationRepository> logger) : base(dbContext, logger) { }


        public async Task<string> AddJseInformation(JseUserModel jseUser)
        {
            try
            {
                var procedureName = "USP_Add_JSEDetails";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", jseUser.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseUser.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseUser.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseUser.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseUser.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", jseUser.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseUser.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@PmCode", jseUser.PmCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@PmEmail", jseUser.PmEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@Location", jseUser.Location, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseUser.BatchId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseUser.TechnologyId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProjectName ", jseUser.ProjectName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseUser.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseInformationRepository.AddJseInformation");
                throw;
            }
        }


        public async Task<string> UpdateJseInformation(JseUserModel jseUser)
        {
            try
            {
                var procedureName = "USP_Update_JSEDetails";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", jseUser.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseUser.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseUser.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseUser.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseUser.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", jseUser.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseUser.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@PmCode", jseUser.PmCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@PmEmail", jseUser.PmEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@Location", jseUser.Location, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseUser.BatchId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseUser.TechnologyId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProjectName ", jseUser.ProjectName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseUser.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseInformationRepository.UpdateJseInformation");
                throw;
            }
        }


        public async Task<string> DeleteJseInformation(JseUserModel jseUser)
        {
            try
            {
                var procedureName = "USP_Delete_JSEDetails";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", jseUser.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseUser.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseUser.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseUser.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseUser.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseInformationRepository.DeleteJseInformation");
                throw;
            }
        }
    }
}

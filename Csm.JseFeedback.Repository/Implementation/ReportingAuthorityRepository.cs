using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository.Contract;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository.Implementation
{ 
    public class ReportingAuthorityRepository : BaseRepository, IReportingAuthorityRepository
    {
        public ReportingAuthorityRepository(CsmDbContext dbContext, ILogger<BaseRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<string> AddJseRa(JseRaDaoModel jseRa)
        {
            try
            {
                var procedureName = "USP_Add_Reporting_Authority";
                var parameters = new DynamicParameters();              
                parameters.Add("@RaCode", jseRa.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaName", jseRa.RaName, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaPhone", jseRa.RaPhone, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseRa.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseRa.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.AddReportingAuthorityInformation");
                throw;
            }
        }

        public async Task<string> UpdateJseRa(JseRaDaoModel jseRa)
        {
            try
            {
                var procedureName = "USP_Update_Reporting_Authority";
                var parameters = new DynamicParameters();
                parameters.Add("@RaCode", jseRa.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaName", jseRa.RaName, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaPhone", jseRa.RaPhone, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseRa.RaEmail, DbType.String, ParameterDirection.Input);              
                parameters.Add("@LoggedInUser", jseRa.LoggedInUser, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", jseRa.IsActive, DbType.Boolean, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.UpdateRAInformation");
                throw;
            }
        }
        public async Task<string> DeleteReportingAuthority(JseRaDaoModel jseRA)
        {
            try
            {
                var procedureName = "USP_Delete_Reporting_Authority";
                var parameters = new DynamicParameters();
                parameters.Add("@RaCode", jseRA.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaName", jseRA.RaName, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseRA.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaPhone", jseRA.RaPhone, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseRA.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.DeleteRAInformation");
                throw;
            }
        }

        public async Task<List<RaDaoModel>> GetJseRaDetails()
        {
            try
            {
                var procedureName = "USP_Get_Ra_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<RaDaoModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in BatchRepository.GetRa");
                throw;
            }
        }

        public async Task<string> CreateMapRAJse(JseUserRAMapModel jseMapRa)
        {
            try
            {
                var procedureName = "USP_Add_Map_Reporting_Authority_Intern";
                var parameters = new DynamicParameters();

                parameters.Add("@EmployeeCode", jseMapRa.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseMapRa.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseMapRa.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseMapRa.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseMapRa.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseMapRa.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", jseMapRa.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseMapRa.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseMapRa.BatchId, DbType.String, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseMapRa.TechnologyId, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseMapRa.LoggedInUser, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", jseMapRa.IsActive, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.AddReportingAuthorityInformation");
                throw;
            }
        }

        public async Task<List<JseRAMapDaoDetailsModel>> GetJseMapRaInternsDetails()
        {
            try
            {
                var procedureName = "USP_Get_Map_Ra_Interns_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<JseRAMapDaoDetailsModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in BatchRepository.GetJseMapRaInternsDetails");
                throw;
            }
        }

        public async Task<string> DeleteMapRAIntern(JseUserRAMapDaoModel jseRAModel)
        {
            try
            {
                var procedureName = "USP_Delete_Map_RA_Intern";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", jseRAModel.Id, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", jseRAModel.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@EmployeeCode", jseRAModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseRAModel.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseRAModel.BatchId, DbType.String, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseRAModel.TechnologyId, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseRAModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.DeleteMapRAInternInformation");
                throw;
            }
        }

        public async Task<string> UpdateMapRAInternData(JseUserRAMapDaoModel jseMapRAModel)
        {
            try
            {
                var procedureName = "USP_Update_Map_Reporting_Authority_Intern";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", jseMapRAModel.Id, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@EmployeeCode", jseMapRAModel.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseMapRAModel.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseMapRAModel.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseMapRAModel.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseMapRAModel.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseMapRAModel.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", jseMapRAModel.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", jseMapRAModel.RaEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseMapRAModel.BatchId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseMapRAModel.TechnologyId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseMapRAModel.LoggedInUser, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", jseMapRAModel.IsActive, DbType.Boolean, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingInformationRepository.UpdateRAInformation");
                throw;
            }
        }
    }
}

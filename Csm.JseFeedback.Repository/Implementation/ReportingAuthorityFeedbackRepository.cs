using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository.Contract;
using Dapper;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository.Implementation
{
    public class ReportingAuthorityFeedbackRepository : BaseRepository,IReportingAuthorityFeedbackRepository
    {
        public ReportingAuthorityFeedbackRepository(CsmDbContext dbContext, ILogger<BaseRepository> logger) : base(dbContext, logger)
        {
        }

        public async Task<string> AddRAFeedback(RAFeedbackModel rAFeedback)
        {
            try
            {
                var procedureName = "USP_Add_RA_Feedback_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@RaCode", rAFeedback.RaCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@EmployeeCode", rAFeedback.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", rAFeedback.IsLogger, DbType.String, ParameterDirection.Input);
                parameters.Add("@AspectRatings", ToDataTable(rAFeedback.AspectRatings), DbType.Object, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception ReportingAuthorityFeedbackRepository.AddRAFeedback");
                throw;
            }
        }

        public async Task<List<RaFeedbackDaoDetailsModel>> GetRAFeedback(FeedbackByRaCodeDaoModel feedback)
        {
            try
            {
                var procedureName = "USP_Get_Ra_Feedback_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RaCode", feedback.RaCode, DbType.String, ParameterDirection.Input);
                    parameters.Add("@EmployeeCode", feedback.EmployeeCode, DbType.String, ParameterDirection.Input);

                    var result = await connection.QueryAsync<RaFeedbackDaoDetailsModel>(
                        sql: procedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in FeedbackRepository.GetAspectDetails");
                throw;
            }
        }

        public async Task<List<FeedbackByRaCodeDaoModel>> GetFeedbackByRaCode(string raCode)
        {
            try
            {
                var procedureName = "USP_Get_ByRaCode_Feedback_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@RaCode", raCode, DbType.String, ParameterDirection.Input);

                    var result = await connection.QueryAsync<FeedbackByRaCodeDaoModel>(
                        sql: procedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in FeedbackRepository.GetAspectDetails");
                throw;
            }
        }

        public DataTable ToDataTable(Dictionary<int, int> aspectRatings)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("FeedbackId", typeof(int));
            dataTable.Columns.Add("Rating", typeof(int));

            foreach (var entry in aspectRatings)
            {
                DataRow row = dataTable.NewRow();
                row["FeedbackId"] = entry.Key;
                row["Rating"] = entry.Value;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

    }
}

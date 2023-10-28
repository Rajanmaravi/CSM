using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Search;
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
    public class JseFeedbackRemarkRepository : BaseRepository, IJseFeedbackRemarkRepository
    {
        public JseFeedbackRemarkRepository(CsmDbContext dbContext, ILogger<JseFeedbackRemarkRepository> logger) : base(dbContext, logger) { }

        public async Task<string> AddJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark)
        {
            try
            {
                var procedureName = "USP_Add_Jse_Feedback_Remarks";
                var parameters = new DynamicParameters();
                parameters.Add("@JSEId", jsefeedbackRemark.JSEId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@FeedbackId", jsefeedbackRemark.FeedbackId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Month", jsefeedbackRemark.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", jsefeedbackRemark.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jsefeedbackRemark.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseFeedbackRemarkRepository.AddJseFeedbackRemark");
                throw;
            }
        }

        public async Task<string> DeleteJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark)
        {
            try
            {
                var procedureName = "USP_Delete_Jse_Feedback_Remarks";
                var parameters = new DynamicParameters();
                parameters.Add("@JSEId", jsefeedbackRemark.JSEId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@FeedbackId", jsefeedbackRemark.FeedbackId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Month", jsefeedbackRemark.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", jsefeedbackRemark.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jsefeedbackRemark.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseFeedbackRemarkRepository.DeleteJseFeedbackRemark");
                throw;
            }
        }

        public async Task<string> UpdateJseFeedbackRemark(JseFeedbackModel jsefeedbackRemark)
        {
            try
            {
                var procedureName = "USP_Update_Jse_Feedback_Remarks";
                var parameters = new DynamicParameters();
                parameters.Add("@JSEId", jsefeedbackRemark.JSEId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@FeedbackId", jsefeedbackRemark.FeedbackId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@Month", jsefeedbackRemark.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", jsefeedbackRemark.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jsefeedbackRemark.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception JseFeedbackRemarkRepository.UpdateJseFeedbackRemark");
                throw;
            }
        }

    }
}

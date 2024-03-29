﻿using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Model.Search;
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
    public class FeedbackRepository :BaseRepository, IFeedbackRepository
    {
        public FeedbackRepository(CsmDbContext dbContext, ILogger<FeedbackRepository> logger):base(dbContext,logger) { }

        public async Task<string> AddFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                var procedureName = "USP_Add_Feedback_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@FeedbackCode", feedback.FeedbackCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FeedbackName", feedback.FeedbackName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", feedback.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.AddFeedback");
                throw;
            }
        }

        public async Task<string> DeleteFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                var procedureName = "USP_Delete_Feedback_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@FeedbackCode", feedback.FeedbackCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", feedback.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.DeleteFeedback");
                throw;
            }
        }

        public async Task<FeedbackModel> GetFeedback(FeedbackSearchModel feedbackSearch)
        {
            try
            {

                var feedbacks = await SearchFeedbacks(feedbackSearch);
                return feedbacks.SingleOrDefault();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.GetFeedback");
                throw;
            }
        }

        public async Task<IEnumerable<FeedbackModel>> SearchFeedbacks(FeedbackSearchModel feedbackSearch)
        {
            try
            {
                var procedureName = "USP_Search_Feedback_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@FeedbackCode", feedbackSearch.FeedbackCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FeedbackName", feedbackSearch.FeedbackName, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.Query<FeedbackModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.SearchFeedbacks");
                throw;
            }
        }

        public async Task<string> UpdateFeedback(FeedbackDaoModel feedback)
        {
            try
            {
                var procedureName = "USP_Update_Feedback_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@FeedbackCode", feedback.FeedbackCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", feedback.IsActive, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@FeedbackName", feedback.FeedbackName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", feedback.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.UpdateFeedback");
                throw;
            }
        }

        public async Task<JseUserDaoDetailsModel> GetMapRAUserDetailsByCode(string internCode)
        {
            try
            {
                var procedureName = "USP_Get_Interns_Details_ByCode";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", internCode, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<JseUserDaoDetailsModel>(
                        sql: procedureName,
                        param: parameters,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.UpdateFeedback");
                throw;
            }
        }

        public async Task<List<AspectDaoModel>> GetAspectDetails()
        {
            try
            {
                var procedureName = "USP_Get_Aspect_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<AspectDaoModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in FeedbackRepository.GetAspectDetails");
                throw;
            }
        }
    }
}

﻿using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
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
    public class BatchRepository :BaseRepository, IBatchRepository
    {
        public BatchRepository(CsmDbContext dbContext, ILogger<BatchRepository> logger):base(dbContext,logger) { }

        public async Task<string> AddBatch(BatchDaoModel batchModel)
        {
            try
            {
                var procedureName = "USP_Add_Batch_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@BatchCode", batchModel.BatchCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchName", batchModel.BatchName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", batchModel.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@Month", batchModel.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", batchModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchRepository.AddBatch");
                throw;
            }
        }

       

        public async Task<string> DeleteBatch(BatchDaoModel batchModel)
        {
            try
            {
                var procedureName = "USP_Delete_Batch_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@BatchCode", batchModel.BatchCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchName", batchModel.BatchName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", batchModel.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@Month", batchModel.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", batchModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchRepository.DeleteBatch");
                throw;
            }
        }

        public async Task<BatchModel> GetBatch(BatchSearchModel searchModel)
        {
            try
            {
                var batches = await SearchBatches(searchModel);
                return batches.SingleOrDefault();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchRepository.GetBatch");
                throw;
            }
        }

        public async Task<IEnumerable<BatchModel>> SearchBatches(BatchSearchModel searchModel)
        {
            try
            {
                var procedureName = "USP_Search_Batch_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@BatchCode", searchModel.BatchCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchName", searchModel.BatchName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", searchModel.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@Month", searchModel.Month, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.Query<BatchModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchRepository.SearchBatches");
                throw;
            }
        }

        public async Task<string> UpdateBatch(BatchDaoModel batchModel)
        {
            try
            {
                var procedureName = "USP_Update_Batch_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@BatchCode", batchModel.BatchCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchName", batchModel.BatchName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Year", batchModel.Year, DbType.String, ParameterDirection.Input);
                parameters.Add("@Month", batchModel.Month, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", batchModel.IsActive, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", batchModel.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception BatchRepository.UpdateBatch");
                throw;
            }
        }

        public async Task<List<BatchDetailsDaoModel>> GetBatchList()
        {
            try
            {
                var procedureName = "USP_GetAll_Batch_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<BatchDetailsDaoModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in BatchRepository.GetBatchList");
                throw;
            }
        }

        public async Task<List<RaDaoModel>> GetRa()
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
    }
}

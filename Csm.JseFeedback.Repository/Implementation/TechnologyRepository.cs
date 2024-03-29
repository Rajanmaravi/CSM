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
    public class TechnologyRepository :BaseRepository, ITechnologyRepository
    {
        public TechnologyRepository(CsmDbContext dbContext, ILogger<TechnologyRepository> logger):base(dbContext,logger) { }

        public async Task<string> AddTechnology(TechnologyDaoModel technology)
        {
            try
            {
                var procedureName = "USP_Add_Technology_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@TechnologyCode", technology.TechnologyCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@TechnologyName", technology.TechnologyName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", technology.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyRepository.AddTechnology");
                throw;
            }
        }

        public async Task<string> DeleteTechnology(TechnologyDaoModel technology)
        {
            try
            {
                var procedureName = "USP_Delete_Technology_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@TechnologyCode", technology.TechnologyCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", technology.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyRepository.DeleteTechnology");
                throw;
            }
        }

        public async Task<TechnologyModel> GetTechnology(TechnologySearchModel technologySearch)
        {
            try
            {

                var technologies = await SearchTechnologies(technologySearch);
                return technologies.SingleOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyRepository.GetTechnology");
                throw;
            }
        }

        public async Task<IEnumerable<TechnologyModel>> SearchTechnologies(TechnologySearchModel technologySearch)
        {
            try
            {
                var procedureName = "USP_Search_Technology_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@TechnologyCode", technologySearch.TechnologyCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@TechnologyName", technologySearch.TechnologyName, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.Query<TechnologyModel>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyRepository.SearchTechnologies");
                throw;
            }
        }

        public async Task<string> UpdateTechnology(TechnologyDaoModel technology)
        {
            try
            {
                var procedureName = "USP_Update_Technology_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@TechnologyCode", technology.TechnologyCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", technology.IsActive, DbType.Boolean, ParameterDirection.Input);
                parameters.Add("@TechnologyName", technology.TechnologyName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", technology.LoggedInUser, DbType.String, ParameterDirection.Input);

                using (var connection = _dbContext.CreateConnection())
                {
                    return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception TechnologyRepository.UpdateTechnology");
                throw;
            }
        }

        public async Task<List<TechnologyDetailsDaoModel>> GetTechnologyList()
        {
            try
            {
                var procedureName = "USP_GetActive_Technology_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<TechnologyDetailsDaoModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in TechnologyRepository.GetTechnologyList");
                throw;
            }
        }
    }
}

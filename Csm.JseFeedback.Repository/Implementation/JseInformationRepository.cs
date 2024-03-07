using Csm.JseFeedback.Model;
using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Csm.JseFeedback.Model.Dao;
using Microsoft.AspNetCore.Http;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Csm.JseFeedback.Repository.CommonDataTable;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace Csm.JseFeedback.Repository
{
    public class JseUserRepository : BaseRepository, IJseUserRepository
    {
        public JseUserRepository(CsmDbContext dbContext, ILogger<JseUserRepository> logger) : base(dbContext, logger) { }


        public async Task<string> AddJseInformation(JseUserAddDaoModel jseUser)
        {
            try
            {
                var procedureName = "USP_Add_Jse_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeCode", jseUser.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseUser.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseUser.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseUser.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseUser.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", "", DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", "", DbType.String, ParameterDirection.Input);
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


        public async Task<string> UpdateJseInformation(JseUserDaoModel jseUser)
        {
            try
            {
                var procedureName = "USP_Update_Jse_Details";
                var parameters = new DynamicParameters(); 
                parameters.Add("@Id", jseUser.Id, DbType.String, ParameterDirection.Input);
                parameters.Add("@EmployeeCode", jseUser.EmployeeCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@FirstName", jseUser.FirstName, DbType.String, ParameterDirection.Input);
                parameters.Add("@MiddleName", jseUser.MiddleName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LastName", jseUser.LastName, DbType.String, ParameterDirection.Input);
                parameters.Add("@Email", jseUser.Email, DbType.String, ParameterDirection.Input);
                parameters.Add("@Mobile", jseUser.Mobile, DbType.String, ParameterDirection.Input);
                parameters.Add("@RaCode", "", DbType.String, ParameterDirection.Input);
                parameters.Add("@RaEmail", "", DbType.String, ParameterDirection.Input);
                parameters.Add("@PmCode", jseUser.PmCode, DbType.String, ParameterDirection.Input);
                parameters.Add("@PmEmail", jseUser.PmEmail, DbType.String, ParameterDirection.Input);
                parameters.Add("@Location", jseUser.Location, DbType.String, ParameterDirection.Input);
                parameters.Add("@BatchId", jseUser.BatchId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@TechnologyId", jseUser.TechnologyId, DbType.Int32, ParameterDirection.Input);
                parameters.Add("@ProjectName ", jseUser.ProjectName, DbType.String, ParameterDirection.Input);
                parameters.Add("@LoggedInUser", jseUser.LoggedInUser, DbType.String, ParameterDirection.Input);
                parameters.Add("@IsActive", jseUser.IsActive, DbType.Boolean, ParameterDirection.Input);

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


        public async Task<string> DeleteJseInformation(JseUserDaoModel jseUser)
        {
            try
            {
                var procedureName = "USP_Delete_Jse_Details";
                var parameters = new DynamicParameters();
                parameters.Add("@Id", jseUser.Id, DbType.String, ParameterDirection.Input);
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

        public async Task<List<JseUserDaoDetailsModel>> GetJseUserDetails()
        {
            try
            {
                var procedureName = "USP_Get_Jse_User_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<JseUserDaoDetailsModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseInformationRepository.GetJseUserDetails");
                throw;
            }
        }

        public async Task<string> UploadJseData(IFormFile formFile)
        {
            try
            {
                using (var stream = formFile.OpenReadStream())
                {
                    // Load the Excel file
                    using (var workbook = new XLWorkbook(stream))
                    {
                        var worksheet = workbook.Worksheet(1); // Assuming data is on the first sheet

                        // Assuming JseUserDaoModel has properties like FirstName, LastName, etc.

                        var jseUserList = new List<JseUserDaoModel>();

                        // Assuming the headers are in the first row
                        var headers = worksheet.FirstRow();

                        foreach (var row in worksheet.RowsUsed().Skip(1)) // Skip the header row
                        {
                            var jseUser = new JseUserDaoModel();

                            // Map columns to properties based on header names
                            foreach (var cell in row.CellsUsed())
                            {
                                var columnName = headers.Cell(cell.Address.ColumnNumber).GetString();
                                var property = typeof(JseUserDaoModel).GetProperty(columnName);

                                if (property != null)
                                {
                                    try
                                    {
                                        var targetType = property.PropertyType;

                                        if (!ReferenceEquals(cell.Value, null) && targetType.IsAssignableFrom(cell.Value.GetType()))
                                        {
                                            // No need to convert, the types are already compatible
                                            property.SetValue(jseUser, cell.Value);
                                        }
                                        else if (!ReferenceEquals(cell.Value, null) && targetType.IsAssignableFrom(typeof(Int32)))
                                        {
                                            // Handle conversion to int separately
                                            if (int.TryParse(cell.Value.ToString(), out int intValue))
                                            {
                                                property.SetValue(jseUser, intValue);
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Error converting property {columnName} to int.");
                                            }
                                        }
                                        else if (!ReferenceEquals(cell.Value, null) && targetType.IsAssignableFrom(typeof(bool)))
                                        {
                                            // Handle conversion to bool separately
                                            if (bool.TryParse(cell.Value.ToString(), out bool boolValue))
                                            {
                                                if (property.PropertyType == typeof(bool?))
                                                {
                                                    // Property is nullable boolean
                                                    property.SetValue(jseUser, boolValue);
                                                }
                                                else if (property.PropertyType == typeof(bool))
                                                {
                                                    // Property is non-nullable boolean
                                                    property.SetValue(jseUser, boolValue);
                                                }
                                                else
                                                {
                                                    // Handle other cases if needed
                                                    Console.WriteLine($"Error: Property {columnName} is not of type bool or bool?");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Error converting property {columnName} to bool.");
                                            }
                                        }
                                        else if (!ReferenceEquals(cell.Value, null) && targetType.IsAssignableFrom(typeof(string)))
                                        {
                                            // Attempt to convert to string if the target type is string
                                            var stringValue = cell.Value.ToString();
                                            property.SetValue(jseUser, stringValue);
                                        }
                                        else if (!ReferenceEquals(cell.Value, null))
                                        {
                                            // Attempt to convert using ChangeType
                                            var value = Convert.ChangeType(cell.Value, targetType);
                                            property.SetValue(jseUser, value);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        // Handle the conversion error, log, or take appropriate action
                                        Console.WriteLine($"Error mapping property {columnName}: {ex.Message}");
                                    }
                                }
                            }

                            jseUserList.Add(jseUser);
                        }


                        // Rest of your code
                        DataTable dtJseUser = JseDataTable.ToDataTable(jseUserList);
                        var procedureName = "USP_Upload_Jse_User_Details";
                        var parameters = new DynamicParameters();
                        parameters.Add("@JseUserList", dtJseUser.AsTableValuedParameter("dbo.JseUserListType"), DbType.Object, ParameterDirection.Input);

                        using (var connection = _dbContext.CreateConnection())
                        {
                            return connection.ExecuteScalar<string>(sql: procedureName, param: parameters, commandType: CommandType.StoredProcedure);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseInformationRepository.UploadJseData");
                throw;
            }
        }


        public async Task<List<JseUserDaoDetailsModel>> GetMapRAJseUserDetails()
        {
            try
            {
                var procedureName = "USP_Get_Map_Ra_Jse_User_Details";

                using (var connection = _dbContext.CreateConnection())
                {
                    var result = await connection.QueryAsync<JseUserDaoDetailsModel>(sql: procedureName, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception in JseInformationRepository.GetMapRAJseUserDetails");
                throw;
            }
        }

    }
}

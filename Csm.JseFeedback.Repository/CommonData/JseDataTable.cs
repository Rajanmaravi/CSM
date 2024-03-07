using Csm.JseFeedback.Model;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository.CommonDataTable
{
    public class JseDataTable
    {
        public static DataTable ToDataTable(List<JseUserDaoModel> items)
        {
            DataTable dataTable = new DataTable("JseUserList");

            // Add columns with specific data types
            dataTable.Columns.Add("EmployeeCode", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("MiddleName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Mobile", typeof(string));
            //dataTable.Columns.Add("RaCode", typeof(string));
            //dataTable.Columns.Add("RaEmail", typeof(string));
            dataTable.Columns.Add("PmCode", typeof(string));
            dataTable.Columns.Add("PmEmail", typeof(string));
            dataTable.Columns.Add("Location", typeof(string));
            dataTable.Columns.Add("ProjectName", typeof(string));
            dataTable.Columns.Add("BatchId", typeof(int));
            dataTable.Columns.Add("TechnologyId", typeof(int));
            //dataTable.Columns.Add("IsActive", typeof(bool));
            dataTable.Columns.Add("LoggedInUser", typeof(string));

            foreach (JseUserDaoModel item in items)
            {
                DataRow newRow = dataTable.NewRow();

                newRow["EmployeeCode"] = item.EmployeeCode;
                newRow["FirstName"] = item.FirstName;
                newRow["MiddleName"] = item.MiddleName;
                newRow["LastName"] = item.LastName;
                newRow["Email"] = item.Email;
                newRow["Mobile"] = item.Mobile;
                //newRow["RaCode"] = item.RaCode;
                //newRow["RaEmail"] = item.RaEmail;
                newRow["PmCode"] = item.PmCode;
                newRow["PmEmail"] = item.PmEmail;
                newRow["Location"] = item.Location;
                newRow["ProjectName"] = item.ProjectName;

                if (item.BatchId.HasValue)
                {
                    newRow["BatchId"] = item.BatchId.Value;
                }
                else
                {
                    newRow["BatchId"] = DBNull.Value;
                }
                if (item.TechnologyId.HasValue)
                {
                    newRow["TechnologyId"] = item.TechnologyId.Value;
                }
                else
                {
                    newRow["TechnologyId"] = DBNull.Value;
                }
               // newRow["IsActive"] = item.IsActive.HasValue ? (object)item.IsActive.Value : DBNull.Value;
                newRow["LoggedInUser"] = item.LoggedInUser;

                dataTable.Rows.Add(newRow);
            }

            return dataTable;
        }     
    }
}

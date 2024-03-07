using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Repository.CommonData;
using Csm.JseFeedback.Repository.Contract;
using Dapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Security;
using MimeKit.Text;
using MailKit.Net.Smtp;
using DocumentFormat.OpenXml.Math;

namespace Csm.JseFeedback.Repository.Implementation
{
    public class FeedbackLinkRepository : BaseRepository, IFeedbackLinkRepository
    {
        //private readonly SmtpSettings _smtpSettings;
        public FeedbackLinkRepository(CsmDbContext dbContext,
            IConfiguration configuration
            , ILogger<FeedbackLinkRepository> logger) : base(dbContext, logger)
        {
            
        }

        public async Task<string> SendLinkToRA(List<FeedbackLinkDaoModel> jseLinkModel)
        {
            string result = "";
            try
            {
                foreach (var feedbackLink in jseLinkModel)
                {
                    string employeeCode = feedbackLink.EmployeeCode;
                    string subject = "Feedback Link";
                    string url = $"http://localhost:4200/admin/feedback/create?EmployeeCode={employeeCode}";
                    string buttonText = "Click Here";
                    string body = $"<p>Click the button below to Create Reporting Authority Feedback From :</p>" +
                                  $"<p><a href=\"{url}\" style=\"padding: 10px 20px; background-color: #3498db; color: #ffffff; text-decoration: none;\">" +
                                  $"{buttonText}</a></p>";

                    result =  SendEmail(feedbackLink.RaEmail, subject, body);                   
                }

                return result;

                //var procedureName = "USP_Send_DBMail_RA Feedback";
                //var tvp = new DataTable();
                //tvp.Columns.Add("EmployeeCode", typeof(string));
                //tvp.Columns.Add("FirstName", typeof(string));
                //tvp.Columns.Add("MiddleName", typeof(string));
                //tvp.Columns.Add("LastName", typeof(string));
                //tvp.Columns.Add("Email", typeof(string));
                //tvp.Columns.Add("Mobile", typeof(string));
                //tvp.Columns.Add("RaCode", typeof(string));
                //tvp.Columns.Add("RaEmail", typeof(string));
                //tvp.Columns.Add("PmCode", typeof(string));
                //tvp.Columns.Add("ProjectName", typeof(string));
                //tvp.Columns.Add("BatchCode", typeof(string));
                //tvp.Columns.Add("BatchName", typeof(string));
                //tvp.Columns.Add("TechnologyName", typeof(string));
                //tvp.Columns.Add("TechnologyCode", typeof(string));
                //tvp.Columns.Add("LoggedInUser", typeof(string));

                //foreach (var feedbackLink in jseLinkModel)
                //{
                //    DataRow row = tvp.NewRow();
                //    row["EmployeeCode"] = feedbackLink.EmployeeCode;
                //    row["FirstName"] = feedbackLink.FirstName;
                //    row["MiddleName"] = feedbackLink.MiddleName;
                //    row["LastName"] = feedbackLink.LastName;
                //    row["Email"] = feedbackLink.Email;
                //    row["Mobile"] = feedbackLink.Mobile;
                //    row["RaCode"] = feedbackLink.RaCode;
                //    row["RaEmail"] = feedbackLink.RaEmail;
                //    row["PmCode"] = feedbackLink.PmCode;
                //    row["ProjectName"] = feedbackLink.ProjectName;
                //    row["BatchCode"] = feedbackLink.BatchCode;
                //    row["BatchName"] = feedbackLink.BatchName;
                //    row["TechnologyName"] = feedbackLink.TechnologyName;
                //    row["TechnologyCode"] = feedbackLink.TechnologyCode;
                //    row["LoggedInUser"] = feedbackLink.LoggedInUser;

                //    tvp.Rows.Add(row);

                //    SendEmail(feedbackLink.Email, subject, body);
                //}

                //var parameters = new DynamicParameters();
                //parameters.Add("@SendLinkFeedback", tvp.AsTableValuedParameter("SendLinkToRAType"));

                //using (var connection = _dbContext.CreateConnection())
                //{
                //    var result = await connection.ExecuteScalarAsync<string>(
                //        sql: procedureName,
                //        param: parameters,
                //        commandType: CommandType.StoredProcedure
                //    );

                //    if(result == "success")
                //       return "success";

                //}


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception FeedbackRepository.AddFeedback");
                throw;
            }
        }      

        public string SendEmail(string to, string subject, string body)
        {
            string result = "";
            try
            {
                var _smtpSettings = _dbContext.GetSmtpSettings();

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("", _smtpSettings.FromEmail));
                message.To.Add(new MailboxAddress("", to));

                message.Subject = subject;

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = body;
                message.Body = bodyBuilder.ToMessageBody();

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(_smtpSettings.SmtpServer, _smtpSettings.SmtpPort, SecureSocketOptions.StartTls);
                    smtpClient.Authenticate(_smtpSettings.SmtpUsername, _smtpSettings.SmtpPassword);
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);
                }

                return result = "success";
            }
            catch(Exception ex)
            {
                return result;
                throw;
            }
            
        }

    }
}

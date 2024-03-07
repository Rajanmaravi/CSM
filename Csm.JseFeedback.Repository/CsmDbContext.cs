using Csm.JseFeedback.Commonlibrary;
using Csm.JseFeedback.Model.Dao;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public class CsmDbContext
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly SmtpSettings _smtpSettings;
        public CsmDbContext(IConfiguration configuration)
        {
            _configuration = configuration??throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration["ConnectionString:SqlConnetion"].ParseToText();

            _smtpSettings = _configuration.GetSection("AppSettings:SmtpSettings").Get<SmtpSettings>();
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);

        public SmtpSettings GetSmtpSettings()
             => _smtpSettings;
    }

}


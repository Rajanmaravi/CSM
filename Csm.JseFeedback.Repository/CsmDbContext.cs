﻿using Csm.JseFeedback.Commonlibrary;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
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
        public CsmDbContext(IConfiguration configuration)
        {
            _configuration = configuration??throw new ArgumentNullException(nameof(configuration));
            _connectionString = _configuration["ConnectionString:SqlConnetion"].ParseToText();
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }

}


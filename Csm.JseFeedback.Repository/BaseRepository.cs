using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Repository
{
    public class BaseRepository
    {
        protected readonly CsmDbContext _dbContext;
        protected readonly ILogger<BaseRepository> _logger;
        public BaseRepository(CsmDbContext dbContext,ILogger<BaseRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
    }
}

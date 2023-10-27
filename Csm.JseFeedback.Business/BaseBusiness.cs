using Csm.JseFeedback.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class BaseBusiness
    {
        protected readonly ILogger<BaseBusiness> _logger;
        public BaseBusiness(ILogger<BaseBusiness> logger)
        {
            _logger = logger??throw new ArgumentNullException(nameof(logger));
        }
    }
}

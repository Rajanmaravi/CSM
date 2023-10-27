using Csm.JseFeedback.Model;
using Csm.JseFeedback.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csm.JseFeedback.Business
{
    public class JseBusiness:BaseBusiness, IJseBusiness
    {
        private readonly IJseRepository _jseRepository;

        public JseBusiness(ILogger<BaseBusiness> logger, IJseRepository jseRepository) : base(logger)
        {
            _jseRepository = jseRepository;
        }

        public async Task<string> AddJse(JseUserModel jseUser)
        {
            return await _jseRepository.AddJseInformation(jseUser);
        }

        public async Task<string> UpdateJse(JseUserModel jseUser)
        {
            return await _jseRepository.UpdateJseInformation(jseUser);
        }

        public async Task<string> DeleteJse(JseUserModel jseUser)
        {
            return await _jseRepository.DeleteJseInformation(jseUser);
        }

    }
}

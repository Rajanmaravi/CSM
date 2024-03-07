using Csm.JseFeedback.Business;
using Csm.JseFeedback.Business.Contract;
using Csm.JseFeedback.Business.Implementation;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Dao;
using Csm.JseFeedback.Model.Validator;
using Csm.JseFeedback.Repository;
using Csm.JseFeedback.Repository.Contract;
using Csm.JseFeedback.Repository.Implementation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
namespace Csm.JseFeedback.Api
{
    public static class ServiceExtensions
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddSingleton<CsmDbContext>()
            .AddTransient<IUserBusiness, UserBusiness>()
            .AddTransient<IUserRepository, UserRepository>()
            .AddTransient<IBatchRepository, BatchRepository>()
            .AddTransient<IBatchBusiness, BatchBusiness>()
            .AddTransient<ITechnologyBusiness, TechnologyBusiness>()
            .AddTransient<ITechnologyRepository, TechnologyRepository>()
            .AddTransient<IFeedbackBusiness, FeedbackBusiness>()
            .AddTransient<IFeedbackRepository, FeedbackRepository>()
            .AddTransient<ITokenService, TokenService>()
            .AddTransient<IRoleBusiness, RoleBusiness>()
            .AddTransient<IRoleRepository, RoleRepository>()
            .AddTransient<FeedbackDaoValidator>()
            .AddTransient<FeedbackSearchValidator>()
            .AddTransient<IJseUserRepository, JseUserRepository>()
            .AddTransient<IJseUserBusiness, JseUserBusiness>()
            .AddTransient<IReportingAuthorityBusiness, ReportingAuthorityBusiness>()
            .AddTransient<IReportingAuthorityRepository,ReportingAuthorityRepository>()
            .AddTransient<IFeedbackLinkBusiness, FeedbackLinkBusiness>()
            .AddTransient<IFeedbackLinkRepository, FeedbackLinkRepository>()
            .AddTransient<IReportingAuthorityFeedbackBusiness, ReportingAuthorityFeedbackBusiness>()
            .AddTransient<IReportingAuthorityFeedbackRepository, ReportingAuthorityFeedbackRepository>()
            .AddTransient<IFeedbackValidationService,FeedbackValidationService>();
            

              

        }
    }
}

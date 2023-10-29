using Csm.JseFeedback.Business;
using Csm.JseFeedback.Model;
using Csm.JseFeedback.Model.Validator;
using Csm.JseFeedback.Repository;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            .AddTransient<IFeedbackValidationService,FeedbackValidationService>();
            

              

        }
    }
}

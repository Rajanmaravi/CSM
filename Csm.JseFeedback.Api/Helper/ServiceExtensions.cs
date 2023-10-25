using Csm.JseFeedback.Business;
using Csm.JseFeedback.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
            .AddTransient<ITokenService, TokenService>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Polling.Domain.Repositories;
using Polling.Infrastructure.Repositories;

namespace Polling.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IQuestionnaireRepository, QuestionnaireRepository>();
            services.AddScoped<IResponseRepository, ResponseRepository>();

            return services;
        }
    }
}

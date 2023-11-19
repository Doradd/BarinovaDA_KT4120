using dariabarinovakt4120.Interfaces;

namespace dariabarinovakt4120.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISubjectService, SubjectService>();

            return services;
        }
    }
}

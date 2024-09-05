using DatabaseImplementation.Abstraction;
using DatabaseImplementation.Implemenmtation;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseImplementation.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddTaskManagementDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
        }
    }
}

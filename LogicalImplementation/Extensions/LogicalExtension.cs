using LogicalImplementation.Abstractions;
using LogicalImplementation.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace LogicalImplementation.Extensions
{
    public static class LogicalExtension
    {
        public static void AddTaskManagementServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskManager, TaskManager>();
        }
    }
}

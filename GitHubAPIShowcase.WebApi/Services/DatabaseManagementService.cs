using GitHubAPIShowcase.Infra.Repository;
using Microsoft.EntityFrameworkCore;

namespace GitHubAPIShowcase.WebApi.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var serviceDb = serviceScope.ServiceProvider.GetService<RepositoryDbContext>();

            serviceDb.Database.Migrate();
        }
    }
}

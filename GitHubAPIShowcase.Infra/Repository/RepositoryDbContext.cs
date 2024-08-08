using GitHubAPIShowcase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubAPIShowcase.Infra.Repository
{
    internal class RepositoryDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\joseh\source\repos\GitHubAPIShowcase\GitHubAPIShowcase.Infra\Database.mdf;Integrated Security=True");

            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var relativePath = @"Database.mdf";
            var absolutePath = Path.Combine(baseDirectory, relativePath);

            var connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={absolutePath};Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Favorite> Favorite { get; set; }
    }
}

using GitHubAPIShowcase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHubAPIShowcase.Infra.Repository
{
    public class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Favorite> Favorite { get; set; }
    }
}

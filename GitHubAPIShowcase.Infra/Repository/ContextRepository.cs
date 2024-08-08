using GitHubAPIShowcase.Domain.Entities;
using GitHubAPIShowcase.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GitHubAPIShowcase.Infra.Repository
{
    public class ContextRepository : IContextRepository
    {
        private readonly RepositoryDbContext _db = new();

        public async Task<bool> ExistsByCheckAlreadyAsync(Favorite favorite)
        {
            return await _db.Favorite.FirstOrDefaultAsync(x => x.Name.Equals(favorite.Name) && x.Owner.Equals(favorite.Owner)) != null;
        }

        public async Task<IList<Favorite>> GetAllAsync()
        {
            return await _db.Favorite.ToListAsync();
        }

        public async Task<bool> InsertAsync(Favorite favorite)
        {
            try
            {
                await _db.Favorite.AddAsync(favorite);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // SaveLogDb();
                return false;
            }
        }
    }
}

using GitHubAPIShowcase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Interfaces
{
    public interface IContextRepository
    {
        Task<bool> InsertAsync(Favorite favorite);
        Task<IList<Favorite>> GetAllAsync();
        Task<bool> ExistsByCheckAlreadyAsync(Favorite favorite);
    }
}

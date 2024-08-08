using GitHubAPIShowcase.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Interfaces
{
    public interface IGitHubFavoriteApplication
    {
        Task<ActionResult<FavoriteViewModel>> GetFavoriteRepository();
        Task<ActionResult<FavoriteViewModel>> SaveFavoriteRepository(FavoriteViewModel view);
    }
}

using GitHubAPIShowcase.Domain.Entities;
using GitHubAPIShowcase.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Interfaces
{
    public interface IGitHubApi
    {
        Task<ActionResult<SearchRepository>> SearchRepositories(string term, int page, int perPage);
        Task<ActionResult<SearchRepository>> GetRepositories(string owner, int page, int perPage);
    }
}

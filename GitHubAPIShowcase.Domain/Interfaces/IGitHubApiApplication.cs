using GitHubAPIShowcase.Domain.ViewModels;

namespace GitHubAPIShowcase.Domain.Interfaces
{
    public interface IGitHubApiApplication
    {
        Task<ActionResult<SearchRepositoryViewModel>> SearchRepositories(string term, int page, int perPage);
        Task<ActionResult<SearchRepositoryViewModel>> GetRepositoriesByOwner(string owner, int page, int perPage);
        Task<ActionResult<RepositoryViewModel>> GetRepository(string owner, long id);
    }
}

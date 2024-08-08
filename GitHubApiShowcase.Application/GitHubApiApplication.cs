using GitHubAPIShowcase.Domain.Entities;
using GitHubAPIShowcase.Domain.Interfaces;
using GitHubAPIShowcase.Domain.ViewModels;

namespace GitHubAPIShowcase.Application
{
    public class GitHubApplication(IGitHubApi gitHubApi) : IGitHubApiApplication
    {
        private readonly IGitHubApi _gitHubApi = gitHubApi;

        public async Task<ActionResult<SearchRepositoryViewModel>> GetRepositoriesByOwner(string owner, int page, int perPage)
        {
            var result = await _gitHubApi.GetRepositories(owner, page, perPage);

            if (result is not null && result.IsValid)
            {
                var searchRepoViewModel = new SearchRepositoryViewModel()
                {
                    TotalCount = result.Item.TotalCount,
                    LastPage = result.Item.LastPage,
                    Repositories = result.Item.Repositories.Select(x => new RepositoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FullName = x.FullName,
                        Description = x.Description,
                        HtmlUrl = x.HtmlUrl,
                        Owner = x.Owner.Login,
                    }).ToArray()
                };

                if (searchRepoViewModel is not null)
                {
                    return new ActionResult<SearchRepositoryViewModel>() { IsValid = result.IsValid, Message = result.Message, Item = searchRepoViewModel };
                }
            }

            return new ActionResult<SearchRepositoryViewModel>()
            {
                IsValid = false,
                Message = (result is null || result.IsValid ? "Desculpe, algo não saiu como planejado." : result.Message)
            };
        }

        public async Task<ActionResult<RepositoryViewModel>> GetRepository(string owner, long id)
        {
            int page = 1;
            int perPage = 100;
            int lastPage = 1;

            List<RepositoryViewModel> listRepositoryViewModels = [];

            ActionResult<SearchRepository>? result = null;

            do
            {
                result = await _gitHubApi.GetRepositories(owner, page, perPage);

                if (result is not null && result.IsValid)
                {
                    listRepositoryViewModels.AddRange(result.Item.Repositories.Select(x => new RepositoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FullName = x.FullName,
                        Description = x.Description,
                        HtmlUrl = x.HtmlUrl,
                        Owner = x.Owner.Login,
                    }).ToArray());

                    lastPage = result.Item.LastPage ?? 0;
                    page++;
                }
            }
            while (lastPage > page);
            
            if (listRepositoryViewModels is not null && listRepositoryViewModels.Count > 1)
            {
                var repositoryViewModel = listRepositoryViewModels.FirstOrDefault(r => r.Id == id);

                if (repositoryViewModel is not null)
                    return new ActionResult<RepositoryViewModel>() { IsValid = result.IsValid, Message = result.Message, Item = repositoryViewModel };

                result.Message = "Repositório não encontrado.";
                result.IsValid = false;
            }

            return new ActionResult<RepositoryViewModel>()
            {
                IsValid = false,
                Message = (result is null || result.IsValid ? "Desculpe, algo não saiu como planejado." : result.Message)
            };
        }

        public async Task<ActionResult<SearchRepositoryViewModel>> SearchRepositories(string term, int page, int perPage)
        {
            var result = await _gitHubApi.SearchRepositories(term, page, perPage);

            if (result is not null && result.IsValid)
            {
                var searchRepoViewModel = new SearchRepositoryViewModel()
                {
                    TotalCount = result.Item.TotalCount,
                    LastPage = result.Item.LastPage,
                    Repositories = result.Item.Repositories.Select(x => new RepositoryViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        FullName = x.FullName,
                        Description = x.Description,
                        HtmlUrl = x.HtmlUrl,
                        Owner = x.Owner.Login,
                    }).ToArray()
                };

                if (searchRepoViewModel is not null)
                {
                    return new ActionResult<SearchRepositoryViewModel>() { IsValid = result.IsValid, Message = result.Message, Item = searchRepoViewModel };
                }
            }

            return new ActionResult<SearchRepositoryViewModel>()
            {
                IsValid = false,
                Message = (result is null || result.IsValid ? "Desculpe, algo não saiu como planejado." : result.Message)
            };
        }
    }
}

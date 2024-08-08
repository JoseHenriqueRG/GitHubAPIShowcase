namespace GitHubAPIShowcase.Domain.ViewModels
{
    public class SearchRepositoryViewModel
    {
        public long TotalCount { get; set; }

        public int? LastPage { get; set; }

        public RepositoryViewModel[] Repositories { get; set; }
    }
}

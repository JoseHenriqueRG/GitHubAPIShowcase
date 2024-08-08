namespace GitHubAPIShowcase.Domain.ViewModels
{
    public class RepositoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string Owner { get; set; }

        public string HtmlUrl { get; set; }

        public string Description { get; set; }
    }
}

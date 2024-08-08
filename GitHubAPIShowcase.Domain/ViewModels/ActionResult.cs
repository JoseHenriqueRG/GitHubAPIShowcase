namespace GitHubAPIShowcase.Domain.ViewModels
{
    public class ActionResult<T> where T : class
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public IList<T> Items { get; set; }
        public T Item { get; set; }
    }
}

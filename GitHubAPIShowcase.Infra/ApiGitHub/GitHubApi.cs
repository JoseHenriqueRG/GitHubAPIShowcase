using GitHubAPIShowcase.Domain.Entities;
using GitHubAPIShowcase.Domain.Interfaces;
using GitHubAPIShowcase.Domain.ViewModels;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace GitHubAPIShowcase.Infra.ApiGitHub
{
    public class GitHubApi : IGitHubApi
    {
        private HttpClient _client;

        public GitHubApi()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.github.com/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
            _client.DefaultRequestHeaders.Add("User-Agent", "GitHub Showcases");
        }

        public async Task<ActionResult<SearchRepository>> GetRepositories(string owner, int page, int perPage)
        {
            try
            {
                var response = await _client.GetAsync($"users/{owner}/repos?page={page}&per_page={perPage}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var repositories = JsonSerializer.Deserialize<Domain.Entities.Repository[]>(result);

                    if (repositories is not null)
                    {
                        SearchRepository searchRepository = new()
                        {
                            Repositories = repositories,
                            LastPage = GetLastPage(response)
                        };

                        return new ActionResult<SearchRepository>() { IsValid = true, Message = "Repositórios carregados com sucesso.", Item = searchRepository };
                    }
                    else
                    {

                    }
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return new ActionResult<SearchRepository>() { IsValid = false, Message = "Não foram encontrados repositórios para este proprietário." };
                }
            }
            catch (Exception ex)
            {
                // SaveLog(ex.Message);
            }

            return new ActionResult<SearchRepository>()
            {
                IsValid = false,
                Message = "Ocorreu um erro ao tentar recuperar a lista de repositórios no momento."
            };
        }

        public async Task<ActionResult<SearchRepository>> SearchRepositories(string term, int page, int perPage)
        {
            try
            {
                var response = await _client.GetAsync($"search/repositories?q={HttpUtility.UrlDecode(term)} in:name,description&page={page}&per_page={perPage}");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var searchRepository = JsonSerializer.Deserialize<SearchRepository>(result);

                    if (searchRepository is not null)
                        searchRepository.LastPage = GetLastPage(response);

                    return new ActionResult<SearchRepository>() { IsValid = true, Message = "Repositórios carregados com sucesso.", Item = searchRepository };
                }
            }
            catch (Exception ex)
            {
                // SaveLog(ex.Message);
            }

            return new ActionResult<SearchRepository>()
            {
                IsValid = false,
                Message = "Ocorreu um erro ao tentar recuperar a lista de repositórios no momento."
            };
        }

        private int GetLastPage(HttpResponseMessage response)
        {
            int lastPage = 1;

            if (response.Headers.TryGetValues("Link", out var linkValues))
            {
                foreach (var link in linkValues)
                {
                    // Exemplo: <.../repos?page=2&per_page=3>; rel="next", <.../repos?page=4&per_page=3>; rel="last"
                    Regex regex = new(@"(?<=<)([\S]*)(?=>; rel=""Last"")", RegexOptions.IgnoreCase);
                    Match match = regex.Match(link);
                    if (match.Success)
                    {
                        string lastLink = match.Groups[1].Value;

                        regex = new(@"[?&]page=(\d+)");
                        match = regex.Match(lastLink);
                        if (match.Success)
                        {
                            string pageNumber = match.Groups[1].Value;

                            if (int.TryParse(pageNumber, out int result))
                            {
                                lastPage = result;
                            }
                        }
                    }
                }
            }

            return lastPage;
        }
    }
}

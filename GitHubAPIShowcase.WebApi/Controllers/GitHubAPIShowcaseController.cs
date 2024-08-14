using GitHubAPIShowcase.Domain.Interfaces;
using GitHubAPIShowcase.Domain.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GitHubAPIShowcase.WebApi.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubAPIShowcaseController(IGitHubApiApplication gitHubApiBusiness, 
        IGitHubFavoriteApplication gitHubFavoriteBusiness) : ControllerBase
    {
        private readonly IGitHubApiApplication _gitHUbApiBusiness = gitHubApiBusiness;
        private readonly IGitHubFavoriteApplication _gitHubFavoriteBusiness = gitHubFavoriteBusiness;

        [HttpGet("SearchRepositories")]
        public async Task<IActionResult> SearchRepositoriesAsync(string term, int? page, int? perPage)
        {
            if(string.IsNullOrEmpty(term))
                return NotFound();

            if(page is null || page < 1)
                page = 1;

            if(perPage is null || perPage < 1)
                perPage = 30;

            var result = await _gitHUbApiBusiness.SearchRepositories(term, (int)page, (int)perPage);

            if (!result.IsValid)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpGet("GetRepositoriesByOwner")]
        public async Task<IActionResult> GetRepositoriesAsync(string owner, int? page, int? perPage)
        {
            if (string.IsNullOrEmpty(owner))
                return NotFound();

            if (page is null || page < 1)
                page = 1;

            if (perPage is null || perPage < 1)
                perPage = 30;

            var result = await _gitHUbApiBusiness.GetRepositoriesByOwner(owner, (int)page, (int)perPage);

            if (!result.IsValid)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpGet("GetRepositoryByOwnerAndId")]
        public async Task<IActionResult> GetRepositoryAsync(string owner, long id)
        {
            if (string.IsNullOrEmpty(owner))
                return NotFound();

            if (id < 1)
                return NotFound();

            var result = await _gitHUbApiBusiness.GetRepository(owner, id);

            if (!result.IsValid)
                return NotFound(result.Message);

            return Ok(result);
        }

        [HttpGet("GetFavorites")]
        public async Task<IActionResult> GetFavoritesAsync()
        {
            var result = await _gitHubFavoriteBusiness.GetFavoriteRepository();
            return Ok(result);
        }

        [HttpPost("SaveFavorite")]
        public async Task<IActionResult> PostFavoriteAsync(FavoriteViewModel view)
        {
            var result = await _gitHubFavoriteBusiness.SaveFavoriteRepository(view);

            if(!result.IsValid)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}

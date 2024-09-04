using GitHubAPIShowcase.Domain.Entities;
using GitHubAPIShowcase.Domain.Interfaces;
using GitHubAPIShowcase.Domain.ViewModels;

namespace GitHubAPIShowcase.Application
{
    public class GitHubFavoriteApplication(IContextRepository contextRepository) : IGitHubFavoriteApplication
    {
        private readonly IContextRepository _contextRepository = contextRepository;

        public async Task<ActionResult<FavoriteViewModel>> GetFavoriteRepository()
        {
            var result = await _contextRepository.GetAllAsync();

            var listFavoriteViewModel = result.Select(r => new FavoriteViewModel { 
                Id = r.Id, 
                Name = r.Name,
                Description = r.Description,
                Owner =  r.Owner
            }).ToList();

            return new ActionResult<FavoriteViewModel> { IsValid = true, Message = "Listado com sucesso.", Items = listFavoriteViewModel };
        }

        public async Task<ActionResult<FavoriteViewModel>> SaveFavoriteRepository(FavoriteViewModel view)
        {
            Favorite favorite = new()
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Owner = view.Owner
            };

            if (await _contextRepository.ExistsByCheckAlreadyAsync(favorite))
            {
                return new ActionResult<FavoriteViewModel> { IsValid = false, Message = "Repositório já consta nos favoritos" };
            }

            var result = await _contextRepository.InsertAsync(favorite);

            if (result)
            {
                return new ActionResult<FavoriteViewModel> { IsValid = true, Message = "Repositório adicionado nos favoritos.", Item = view };
            }

            return new ActionResult<FavoriteViewModel> { IsValid = false, Message = "Ocorreu um erro ao salvar.", Item = view };
        }
    }
}

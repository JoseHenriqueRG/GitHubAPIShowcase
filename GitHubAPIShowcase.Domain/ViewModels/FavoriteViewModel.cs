using GitHubAPIShowcase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.ViewModels
{
    public class FavoriteViewModel
    {
        public long Id { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

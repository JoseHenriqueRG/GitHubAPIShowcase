using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Entities
{
    public class SearchRepository
    {
        [JsonPropertyName("total_count")]
        public long TotalCount { get; set; }

        [JsonPropertyName("incomplete_results")]
        public bool IncompleteResults { get; set; }

        public int? LastPage { get; set; }

        [JsonPropertyName("items")]
        public Repository[] Repositories { get; set; }
    }
}

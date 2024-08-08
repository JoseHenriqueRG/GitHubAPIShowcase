using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Entities
{
    public class Permissions
    {
        [JsonPropertyName("pull")]
        public bool Pull { get; set; }

        [JsonPropertyName("push")]
        public bool Push { get; set; }

        [JsonPropertyName("admin")]
        public bool Admin { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace GitHubAPIShowcase.Domain.Entities
{
    public class AdvancedSecurity
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}

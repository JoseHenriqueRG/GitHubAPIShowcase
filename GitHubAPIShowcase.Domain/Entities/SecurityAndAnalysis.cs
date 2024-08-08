using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Entities
{
    public class SecurityAndAnalysis
    {
        [JsonPropertyName("advanced_security")]
        public AdvancedSecurity AdvancedSecurity { get; set; }

        [JsonPropertyName("secret_scanning")]
        public SecretScanning SecretScanning { get; set; }

        [JsonPropertyName("secret_scanning_push_protection")]
        public SecretScanningPushProtection SecretScanningPushProtection { get; set; }

        [JsonPropertyName("secret_scanning_non_provider_patterns")]
        public SecretScanningNonProviderPatterns SecretScanningNonProviderPatterns { get; set; }
    }
}

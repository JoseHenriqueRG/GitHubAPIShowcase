﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GitHubAPIShowcase.Domain.Entities
{
    public class SecretScanning
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}

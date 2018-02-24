using System;
using Newtonsoft.Json;

namespace Lands.Models
{
    public class Language
    {
        [JsonProperty(PropertyName = "iso6391")]
        public string Iso6391 { get; set; }

        [JsonProperty(PropertyName = "iso6392")]
        public string Iso6392 { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "nativename")]
        public string NativeName { get; set; }
    }
}

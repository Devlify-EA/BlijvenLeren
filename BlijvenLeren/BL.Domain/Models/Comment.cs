using BL.Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace BL.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Comment
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }
    }
}

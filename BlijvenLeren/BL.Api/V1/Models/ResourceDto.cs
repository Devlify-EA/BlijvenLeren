using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BL.Api.V1.Models
{
    [ExcludeFromCodeCoverage]
    public class ResourceDto
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [Required]
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [Required]
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [Required]
        [JsonProperty(PropertyName = "comments")]
        public List<CommentDto> Comments { get; set; }
    }
}

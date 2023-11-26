using BL.Api.Swashbuckle;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace BL.Api.V1.Models
{
    [ExcludeFromCodeCoverage]
    public class CommentDto
    {
        [Required]
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "approved")]
        [SwaggerIgnoreProperty]
        public bool Approved { get; set; }
    }
}

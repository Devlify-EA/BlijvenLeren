using BL.Domain.Enums;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace BL.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Resource : IDocument
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "documentType")]
        public DocumentType DocType { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public List<Comment> Comments { get; set; }
    }
}

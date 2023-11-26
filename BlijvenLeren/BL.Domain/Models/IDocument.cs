using BL.Domain.Enums;

namespace BL.Domain.Models
{
    public interface IDocument
    {
        public DocumentType DocType { get; set; }
    }
}

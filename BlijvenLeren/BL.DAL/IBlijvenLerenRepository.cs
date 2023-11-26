using BL.Domain.Enums;
using BL.Domain.Models;

namespace BL.DAL
{
    public interface IBlijvenLerenRepository
    {
        Task<IList<T>> GetDocumentsByTypeAsync<T>(DocumentType documentType) where T : IDocument;
        Task<Resource> CreateResourceAsync(Resource resource);
        Task<Resource> UpdateResourceAsync(Resource resource);
        Task<bool> DeleteResourceAsync(string id);
        Task<Resource> GetResourceByIdAsync(string id);
    }
}

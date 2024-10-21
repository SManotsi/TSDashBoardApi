using System.Threading.Tasks;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Application
{
    public interface IDocumentsService
    {
        Task<Documents> GetDocumentsByIdAsync(int id);
        Task<IEnumerable<Documents>> GetAllDocumentsAsync();
        Task AddDocumentsAsync(Documents documents);
        Task UpdateDocumentsAsync(Documents documents);
        Task DeleteDocumentsAsync(int id);

        // New method for sharing documents
        Task<string> SaveFileAsync(IFormFile file); // Add this line
        Task ShareDocumentAsync(int documentId, string email);
        Task<IEnumerable<Documents>> SearchDocumentsAsync(string name);
    }
}

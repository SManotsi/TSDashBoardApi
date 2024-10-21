using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Required for IFormFile
using TSDashBoardApi.Core.Domain;
using TSDashBoardApi.Core.Repository;

namespace TSDashBoardApi.Application.Services
{
    public class DocumentsService : IDocumentsService
    {
        private readonly IGenericRepository<Documents> _documentsRepository;
        private readonly IEmailService _emailService;

        public DocumentsService(IGenericRepository<Documents> documentsRepository, IEmailService emailService)
        {
            _documentsRepository = documentsRepository ?? throw new ArgumentNullException(nameof(documentsRepository));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<Documents> GetDocumentsByIdAsync(int id)
        {
            var document = await _documentsRepository.GetByIdAsync(id);
            if (document == null)
            {
                throw new KeyNotFoundException($"Document with ID {id} not found.");
            }
            return document;
        }

        public async Task<IEnumerable<Documents>> GetAllDocumentsAsync()
        {
            return await _documentsRepository.GetAllAsync();
        }

        public async Task AddDocumentsAsync(Documents documents)
        {
            if (documents == null) throw new ArgumentNullException(nameof(documents));
            await _documentsRepository.AddAsync(documents);
        }

        public async Task UpdateDocumentsAsync(Documents documents)
        {
            if (documents == null) throw new ArgumentNullException(nameof(documents));
            await _documentsRepository.UpdateAsync(documents);
        }

        public async Task DeleteDocumentsAsync(int id)
        {
            await _documentsRepository.DeleteAsync(id);
        }

        public async Task ShareDocumentAsync(int documentId, string email)
        {
            var document = await _documentsRepository.GetByIdAsync(documentId);
            if (document == null) throw new KeyNotFoundException("Document not found");

            var documentLink = GenerateDocumentLink(document);
            var emailMessage = $"Please find the document here: {documentLink}";
            await _emailService.SendEmailAsync(email, "Shared Document", emailMessage);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("File cannot be empty.", nameof(file));

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{uniqueFileName}";
        }

        // Implementing the search method
        public async Task<IEnumerable<Documents>> SearchDocumentsAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Search term cannot be empty.", nameof(name));

            var allDocuments = await _documentsRepository.GetAllAsync();
            return allDocuments.Where(doc => doc.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        private string GenerateDocumentLink(Documents document)
        {
            return $"http://localhost:7179/documents/{document.Id}"; // Adjust this as necessary based on your routing
        }
    }
}

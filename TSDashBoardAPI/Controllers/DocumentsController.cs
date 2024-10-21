using Microsoft.AspNetCore.Http; // Required for IFormFile
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentsService _documentsService;

        public DocumentController(IDocumentsService documentsService)
        {
            _documentsService = documentsService;
        }

        // Get a document by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentsById(int id)
        {
            var document = await _documentsService.GetDocumentsByIdAsync(id);
            if (document == null) return NotFound();
            return Ok(document);
        }

        // Get all documents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documents>>> GetAllDocuments()
        {
            var documents = await _documentsService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        // Post route for creating a document and uploading a file
        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromForm] Documents documents, IFormFile uploadedFile)
        {
            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                return BadRequest("File is required.");
            }

            // Save the file and set the FilePath property
            documents.FilePath = await _documentsService.SaveFileAsync(uploadedFile);

            // Ensure the file was saved
            if (string.IsNullOrEmpty(documents.FilePath))
            {
                return BadRequest("Failed to save the file.");
            }

            // Check if all required fields are set
            if (string.IsNullOrWhiteSpace(documents.Name) || documents.UploadDate == default)
            {
                return BadRequest("Document details (Name and UploadDate) are required.");
            }

            await _documentsService.AddDocumentsAsync(documents);
            return CreatedAtAction(nameof(GetDocumentsById), new { id = documents.Id }, documents);
        }

        // Separate upload document action (optional if needed)
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocuments([FromForm] Documents documents, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required.");
            }

            // Save the file and set the FilePath property
            documents.FilePath = await _documentsService.SaveFileAsync(file);

            // Ensure the file was saved
            if (string.IsNullOrEmpty(documents.FilePath))
            {
                return BadRequest("Failed to save the file.");
            }

            // Check if all required fields are set
            if (string.IsNullOrWhiteSpace(documents.Name) || documents.UploadDate == default)
            {
                return BadRequest("Document details (Name and UploadDate) are required.");
            }

            await _documentsService.AddDocumentsAsync(documents);
            return CreatedAtAction(nameof(GetDocumentsById), new { id = documents.Id }, documents);
        }

        // Update a document
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocuments(int id, [FromBody] Documents documents)
        {
            if (id != documents.Id)
            {
                return BadRequest("Document ID mismatch.");
            }

            // Check if the document exists before updating
            var existingDocument = await _documentsService.GetDocumentsByIdAsync(id);
            if (existingDocument == null)
            {
                return NotFound(); // Document not found
            }

            await _documentsService.UpdateDocumentsAsync(documents);
            return NoContent();
        }

        // Delete a document
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocuments(int id)
        {
            var document = await _documentsService.GetDocumentsByIdAsync(id);
            if (document == null)
            {
                return NotFound(); // Document not found
            }

            await _documentsService.DeleteDocumentsAsync(id);
            return NoContent();
        }

        // Share a document via email
        [HttpPost("share/{id}")]
        public async Task<IActionResult> ShareDocument(int id, [FromBody] string email)
        {
            var document = await _documentsService.GetDocumentsByIdAsync(id);
            if (document == null) return NotFound();

            await _documentsService.ShareDocumentAsync(id, email);
            return Ok("Document shared successfully.");
        }

        // Search documents by name
        [HttpGet("search")]
        public async Task<IActionResult> SearchDocuments(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Search term cannot be empty.");
            }

            var documents = await _documentsService.SearchDocumentsAsync(name);
            return Ok(documents);
        }
    }
}

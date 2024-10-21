namespace TeksaHDashboard.Models
{
    public class DocumentsViewModel
    {
        public required int Id { get; set; } // Unique identifier for the document
        public required string Name { get; set; } // Name of the document
        public required DateTime UploadDate { get; set; } // Date the document was uploaded
        public required string FilePath { get; set; } // Path to the uploaded document file

        // New property for sharing the document via email
        public string? Email { get; set; } // Optional, used when sharing the document
    }
}

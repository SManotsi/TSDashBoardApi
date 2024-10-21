namespace TSDashBoardApi.Core.Domain
{
    public class Documents
    {
        public required int Id { get; set; } 
        public required string Name { get; set; }
        public required DateTime UploadDate { get; set; }
        public required string? FilePath { get; set; }

        // New property for sharing document via email
        public string? Email { get; set; } // Optional, used when sharing the document
    }
}

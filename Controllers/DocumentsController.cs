using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

public class DocumentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DocumentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Documents
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("DocumentsAPI");
        var response = await client.GetAsync("api/Document");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var documents = JsonConvert.DeserializeObject<IEnumerable<DocumentsViewModel>>(jsonString) ?? new List<DocumentsViewModel>();
            return View(documents);
        }

        // Log error if necessary
        return View(new List<DocumentsViewModel>()); // Return an empty list if API call fails
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DocumentsViewModel documents, IFormFile uploadedFile)
    {
        if (uploadedFile != null && uploadedFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsFolder); // Ensure the directory exists

            var fileName = ContentDispositionHeaderValue.Parse(uploadedFile.ContentDisposition).FileName.Trim('"');
            var filePath = Path.Combine(uploadsFolder, fileName); // Create file path

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(stream); // Save the file to the server
            }

            documents.FilePath = $"/uploads/{fileName}"; // Set the file path in the model
        }

        var client = _httpClientFactory.CreateClient("DocumentsAPI");

        // Prepare the form data with file
        var formData = new MultipartFormDataContent();
        formData.Add(new StringContent(documents.Name), "Name");
        formData.Add(new StringContent(documents.UploadDate.ToString("yyyy-MM-ddTHH:mm")), "UploadDate"); // Ensure correct datetime format

        if (!string.IsNullOrEmpty(documents.Email))
        {
            formData.Add(new StringContent(documents.Email), "Email");
        }

        if (uploadedFile != null && uploadedFile.Length > 0)
        {
            var fileStreamContent = new StreamContent(uploadedFile.OpenReadStream());
            formData.Add(fileStreamContent, "uploadedFile", uploadedFile.FileName);
        }

        var response = await client.PostAsync("api/Document", formData);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }

        // If something goes wrong, return the form back with data and errors
        return View(documents);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("DocumentsAPI");
        var response = await client.GetAsync($"api/Document/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var documents = JsonConvert.DeserializeObject<DocumentsViewModel>(jsonString);

            if (documents != null)
            {
                return View(documents);
            }
        }

        return NotFound(); // Handle case where document is not found or deserialization fails
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DocumentsViewModel documents)
    {
        if (documents == null)
        {
            return BadRequest("Document data is required.");
        }

        if (id != documents.Id)
        {
            return BadRequest("Document ID mismatch."); // Ensure the document ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("DocumentsAPI");
            var response = await client.PutAsJsonAsync($"api/Document/{id}", documents);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(documents); // If model is invalid, return the form with validation errors
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("DocumentsAPI");
        var response = await client.GetAsync($"api/Document/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var documents = JsonConvert.DeserializeObject<DocumentsViewModel>(jsonString);

            if (documents != null)
            {
                return View(documents); // Return the Delete confirmation view
            }
        }

        return NotFound(); // Handle case where document is not found or deserialization fails
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("DocumentsAPI");
        var response = await client.DeleteAsync($"api/Document/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("DocumentsAPI");
        var response = await client.GetAsync($"api/Document/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var documents = JsonConvert.DeserializeObject<DocumentsViewModel>(jsonString);

            if (documents != null)
            {
                return View(documents);
            }
        }

        return NotFound(); // Handle case where document is not found or deserialization fails
    }
    public class EmailRequest
    {
        public string Email { get; set; }
        public string File { get; set; }
    }
        [HttpPost]
    public async Task<IActionResult> ShareDocument(int documentId, [FromBody] EmailRequest emailRequest)
    {
        var documents = await 
        if (documents == null)
        {
            return BadRequest("Document data is required.");
        }

        if (id != documents.Id)
        {
            return BadRequest("Document ID mismatch."); // Ensure the document ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("DocumentsAPI");
            var response = await client.PutAsJsonAsync($"api/Document/share/{id}", documents);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(documents); // If model is invalid, return the form with validation errors
    }
}

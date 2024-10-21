using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class InvoiceController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public InvoiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("InvoicesAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Invoices"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var invoices = JsonConvert.DeserializeObject<IEnumerable<InvoicesViewModel>>(jsonString);
            return View(invoices);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<InvoicesViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InvoicesViewModel invoices)
    {

        var client = _httpClientFactory.CreateClient("InvoicesAPI");
        var response = await client.PostAsJsonAsync("api/Invoices", invoices); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(invoices); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("InvoicesAPI");
        var response = await client.GetAsync($"api/invoices/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var invoice = JsonConvert.DeserializeObject<InvoicesViewModel>(jsonString);
            return View(invoice);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, InvoicesViewModel invoices)
    {
        if (id != invoices.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("InvoicesAPI");
            var response = await client.PutAsJsonAsync($"api/invoices/{id}", invoices); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(invoices); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("InvoicesAPI");
        var response = await client.GetAsync($"api/invoices/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var invoices = JsonConvert.DeserializeObject<InvoicesViewModel>(jsonString);
            return View(invoices); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("InvoicesAPI");
        var response = await client.DeleteAsync($"api/invoices/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("InvoicesAPI");
        var response = await client.GetAsync($"api/invoices/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var invoices = JsonConvert.DeserializeObject<InvoicesViewModel>(jsonString);
            return View(invoices);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



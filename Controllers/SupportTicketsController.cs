using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class SupportTicketController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SupportTicketController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("SupportTicketsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/SupportTickets"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var supportTickets = JsonConvert.DeserializeObject<IEnumerable<SupportTicketsViewModel>>(jsonString);
            return View(supportTickets);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<SupportTicketsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(SupportTicketsViewModel supportTickets)
    {

        var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
        var response = await client.PostAsJsonAsync("api/SupportTickets", supportTickets); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(supportTickets); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
        var response = await client.GetAsync($"api/SupportTickets/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var supportTicket = JsonConvert.DeserializeObject<SupportTicketsViewModel>(jsonString);
            return View(supportTicket);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, SupportTicketsViewModel supportTickets)
    {
        if (id != supportTickets.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
            var response = await client.PutAsJsonAsync($"api/SupportTickets/{id}", supportTickets); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(supportTickets); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
        var response = await client.GetAsync($"api/SupportTickets/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var supportTickets = JsonConvert.DeserializeObject<SupportTicketsViewModel>(jsonString);
            return View(supportTickets); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
        var response = await client.DeleteAsync($"api/SupportTickets/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("SupportTicketsAPI");
        var response = await client.GetAsync($"api/SupportTickets/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var supportTickets = JsonConvert.DeserializeObject<SupportTicketsViewModel>(jsonString);
            return View(supportTickets);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



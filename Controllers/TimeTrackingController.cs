using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class TimeTrackingsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TimeTrackingsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("TimeTrackingAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/TimeTrackings"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var timeTracking = JsonConvert.DeserializeObject<IEnumerable<TimeTrackingViewModel>>(jsonString);
            return View(timeTracking);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<TimeTrackingViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TimeTrackingViewModel timeTracking)
    {

        var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
        var response = await client.PostAsJsonAsync("api/TimeTrackings", timeTracking); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(timeTracking); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
        var response = await client.GetAsync($"api/TimeTrackings/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var timeTracking = JsonConvert.DeserializeObject<TimeTrackingViewModel>(jsonString);
            return View(timeTracking);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TimeTrackingViewModel timeTracking)
    {
        if (id != timeTracking.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
            var response = await client.PutAsJsonAsync($"api/TimeTrackings/{id}", timeTracking); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(timeTracking); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
        var response = await client.GetAsync($"api/TimeTrackings/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var timeTracking = JsonConvert.DeserializeObject<TimeTrackingViewModel>(jsonString);
            return View(timeTracking); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
        var response = await client.DeleteAsync($"api/TimeTrackings/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("TimeTrackingAPI");
        var response = await client.GetAsync($"api/TimeTrackings/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var timeTracking = JsonConvert.DeserializeObject<TimeTrackingViewModel>(jsonString);
            return View(timeTracking);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



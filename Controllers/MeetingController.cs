using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class MeetingsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MeetingsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("MeetingsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Meeting/GetAllMeeting"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meetings = JsonConvert.DeserializeObject<IEnumerable<MeetingsViewModel>>(jsonString);
            return View(meetings);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<MeetingsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MeetingsViewModel meetings)
    {

            var client = _httpClientFactory.CreateClient("MeetingsAPI");
            var response = await client.PostAsJsonAsync("api/Meeting/AddMeetings", meetings); // Send POST request to create meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
            }
        

        return View(meetings); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingsAPI");
        var response = await client.GetAsync($"api/meetings/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meeting = JsonConvert.DeserializeObject<MeetingsViewModel>(jsonString);
            return View(meeting);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MeetingsViewModel meeting)
    {
        if (id != meeting.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("MeetingsAPI");
            var response = await client.PutAsJsonAsync($"api/meetings/{id}", meeting); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(meeting); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingsAPI");
        var response = await client.GetAsync($"api/meetings/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meeting = JsonConvert.DeserializeObject<MeetingsViewModel>(jsonString);
            return View(meeting); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingsAPI");
        var response = await client.DeleteAsync($"api/meetings/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingsAPI");
        var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meeting = JsonConvert.DeserializeObject<MeetingsViewModel>(jsonString);
            return View(meeting);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
  //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



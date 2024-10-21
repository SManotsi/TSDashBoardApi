using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class ActivityController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ActivityController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("ActivitiesAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Activity"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var activities = JsonConvert.DeserializeObject<IEnumerable<ActivitiesViewModel>>(jsonString);
            return View(activities);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<ActivitiesViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ActivitiesViewModel activities)
    {

        var client = _httpClientFactory.CreateClient("ActivitiesAPI");
        var response = await client.PostAsJsonAsync("api/Activity/AddActivities", activities); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(activities); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("ActivitiesAPI");
        var response = await client.GetAsync($"api/activities/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var activity = JsonConvert.DeserializeObject<ActivitiesViewModel>(jsonString);
            return View(activity);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ActivitiesViewModel activity)
    {
        if (id != activity.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("ActivitiesAPI");
            var response = await client.PutAsJsonAsync($"api/activities/{id}", activity); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(activity); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("ActivitiesAPI");
        var response = await client.GetAsync($"api/activities/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var activity = JsonConvert.DeserializeObject<ActivitiesViewModel>(jsonString);
            return View(activity); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("ActivitiesAPI");
        var response = await client.DeleteAsync($"api/activities/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("ActivitiesAPI");
        var response = await client.GetAsync($"api/activities/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var activity = JsonConvert.DeserializeObject<ActivitiesViewModel>(jsonString);
            return View(activity);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



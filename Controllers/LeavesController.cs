using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class LeaveController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public LeaveController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("LeavesAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Leave"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var leaves = JsonConvert.DeserializeObject<IEnumerable<LeavesViewModel>>(jsonString);
            return View(leaves);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<LeavesViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LeavesViewModel leaves)
    {

        var client = _httpClientFactory.CreateClient("LeavesAPI");
        var response = await client.PostAsJsonAsync("api/Leave", leaves); // Send POST request to create meeting

         if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(leaves); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("LeavesAPI");
        var response = await client.GetAsync($"api/Leave/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var leaves = JsonConvert.DeserializeObject<LeavesViewModel>(jsonString);
            return View(leaves);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LeavesViewModel leaves)
    {
        if (id != leaves.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("LeavesAPI");
            var response = await client.PutAsJsonAsync($"api/Leave/{id}", leaves); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(leaves); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("LeavesAPI");
        var response = await client.GetAsync($"api/Leave/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var leaves = JsonConvert.DeserializeObject<LeavesViewModel>(jsonString);
            return View(leaves); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("LeavesAPI");
        var response = await client.DeleteAsync($"api/Leave/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("LeavesAPI");
        var response = await client.GetAsync($"api/Leave/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var leaves = JsonConvert.DeserializeObject<LeavesViewModel>(jsonString);
            return View(leaves);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



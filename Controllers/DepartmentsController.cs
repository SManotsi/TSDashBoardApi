using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class DepartmentController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DepartmentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("DepartmentsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Department"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<IEnumerable<DepartmentsViewModel>>(jsonString);
            return View(departments);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<DepartmentsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DepartmentsViewModel departments)
    {

        var client = _httpClientFactory.CreateClient("DepartmentsAPI");
        var response = await client.PostAsJsonAsync("api/Department", departments); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(departments); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("DepartmentsAPI");
        var response = await client.GetAsync($"api/Department/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<DepartmentsViewModel>(jsonString);
            return View(departments);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DepartmentsViewModel departments)
    {
        if (id != departments.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("DepartmentsAPI");
            var response = await client.PutAsJsonAsync($"api/Department/{id}", departments); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(departments); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("DepartmentsAPI");
        var response = await client.GetAsync($"api/Department/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<DepartmentsViewModel>(jsonString);
            return View(departments); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("DepartmentsAPI");
        var response = await client.DeleteAsync($"api/Department/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("DepartmentsAPI");
        var response = await client.GetAsync($"api/Department/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var departments = JsonConvert.DeserializeObject<DepartmentsViewModel>(jsonString);
            return View(departments);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



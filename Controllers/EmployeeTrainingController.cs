using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class EmployeeTrainingController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeTrainingController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/EmployeeTraining"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employeeTraining = JsonConvert.DeserializeObject<IEnumerable<EmployeeTrainingViewModel>>(jsonString);
            return View(employeeTraining);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<EmployeeTrainingViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeeTrainingViewModel employeeTraining)
    {

            var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
            var response = await client.PostAsJsonAsync("api/EmployeeTraining", employeeTraining); // Send POST request to create meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
            }
        

        return View(employeeTraining); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
        var response = await client.GetAsync($"api/EmployeeTraining/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employeeTraining = JsonConvert.DeserializeObject<EmployeeTrainingViewModel>(jsonString);
            return View(employeeTraining);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeeTrainingViewModel employeeTraining)
    {
        if (id != employeeTraining.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
            var response = await client.PutAsJsonAsync($"api/EmployeeTraining/{id}", employeeTraining); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(employeeTraining); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
        var response = await client.GetAsync($"api/employeeTraining/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employeeTraining = JsonConvert.DeserializeObject<EmployeeTrainingViewModel>(jsonString);
            return View(employeeTraining); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
        var response = await client.DeleteAsync($"api/EmployeeTraining/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeeTrainingsAPI");
        var response = await client.GetAsync($"api/EmployeeTraining/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employeeTraining = JsonConvert.DeserializeObject<EmployeeTrainingViewModel>(jsonString);
            return View(employeeTraining);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
  //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



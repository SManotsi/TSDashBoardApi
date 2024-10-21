using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class EmployeeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public EmployeeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("EmployeesAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Employee"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeesViewModel>>(jsonString);
            return View(employees);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<EmployeesViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(EmployeesViewModel employees)
    {

        var client = _httpClientFactory.CreateClient("EmployeesAPI");
        var response = await client.PostAsJsonAsync("api/Employee", employees); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(employees); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeesAPI");
        var response = await client.GetAsync($"api/Employee/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<EmployeesViewModel>(jsonString);
            return View(employees);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EmployeesViewModel employees)
    {
        if (id != employees.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("EmployeesAPI");
            var response = await client.PutAsJsonAsync($"api/Employee/{id}", employees); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(employees); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeesAPI");
        var response = await client.GetAsync($"api/Employee/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<EmployeesViewModel>(jsonString);
            return View(employees); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeesAPI");
        var response = await client.DeleteAsync($"api/Employee/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("EmployeesAPI");
        var response = await client.GetAsync($"api/employees/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<EmployeesViewModel>(jsonString);
            return View(employees);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class BudgetsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BudgetsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("BudgetsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Budget"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var budgets = JsonConvert.DeserializeObject<IEnumerable<BudgetsViewModel>>(jsonString);
            return View(budgets);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<BudgetsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BudgetsViewModel budgets)
    {

        var client = _httpClientFactory.CreateClient("BudgetsAPI");
        var response = await client.PostAsJsonAsync("api/Budget", budgets); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(budgets); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("BudgetsAPI");
        var response = await client.GetAsync($"api/Budget/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var budgets = JsonConvert.DeserializeObject<BudgetsViewModel>(jsonString);
            return View(budgets);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BudgetsViewModel budgets)
    {
        if (id != budgets.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("BudgetsAPI");
            var response = await client.PutAsJsonAsync($"api/Budget", budgets); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(budgets); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("BudgetsAPI");
        var response = await client.GetAsync($"api/Budget/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var budgets = JsonConvert.DeserializeObject<BudgetsViewModel>(jsonString);
            return View(budgets); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("BudgetsAPI");
        var response = await client.DeleteAsync($"api/Budget/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("BudgetsAPI");
        var response = await client.GetAsync($"api/Budget/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var budgets = JsonConvert.DeserializeObject<BudgetsViewModel>(jsonString);
            return View(budgets);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



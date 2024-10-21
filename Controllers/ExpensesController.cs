using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class ExpenseController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExpenseController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("ExpensesAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Expense"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var expenses = JsonConvert.DeserializeObject<IEnumerable<ExpensesViewModel>>(jsonString);
            return View(expenses);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<ExpensesViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ExpensesViewModel expenses)
    {

        var client = _httpClientFactory.CreateClient("ExpensesAPI");
        var response = await client.PostAsJsonAsync("api/Expense/AddExpenses", expenses); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(expenses); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("ExpensesAPI");
        var response = await client.GetAsync($"api/expenses/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var expense = JsonConvert.DeserializeObject<ExpensesViewModel>(jsonString);
            return View(expense);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ExpensesViewModel expense)
    {
        if (id != expense.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("ExpensesAPI");
            var response = await client.PutAsJsonAsync($"api/expenses/{id}", expense); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(expense); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("ExpensesAPI");
        var response = await client.GetAsync($"api/expenses/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var expense = JsonConvert.DeserializeObject<ExpensesViewModel>(jsonString);
            return View(expense); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("ExpensesAPI");
        var response = await client.DeleteAsync($"api/expenses/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("ExpensesAPI");
        var response = await client.GetAsync($"api/expenses/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var expense = JsonConvert.DeserializeObject<ExpensesViewModel>(jsonString);
            return View(expense);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



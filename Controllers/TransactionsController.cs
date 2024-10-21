using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class TransactionController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TransactionController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("TransactionsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Transaction"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<IEnumerable<TransactionsViewModel>>(jsonString);
            return View(transactions);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<TransactionsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TransactionsViewModel transactions)
    {

        var client = _httpClientFactory.CreateClient("TransactionsAPI");
        var response = await client.PostAsJsonAsync("api/Transaction", transactions); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(transactions); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("TransactionsAPI");
        var response = await client.GetAsync($"api/Transaction/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<TransactionsViewModel>(jsonString);
            return View(transactions);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TransactionsViewModel transactions)
    {
        if (id != transactions.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("TransactionsAPI");
            var response = await client.PutAsJsonAsync($"api/Transaction/{id}", transactions); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(transactions); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("TransactionsAPI");
        var response = await client.GetAsync($"api/Transaction/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<TransactionsViewModel>(jsonString);
            return View(transactions); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("TransactionsAPI");
        var response = await client.DeleteAsync($"api/Transaction/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("TransactionsAPI");
        var response = await client.GetAsync($"api/Transaction/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var transactions = JsonConvert.DeserializeObject<TransactionsViewModel>(jsonString);
            return View(transactions);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



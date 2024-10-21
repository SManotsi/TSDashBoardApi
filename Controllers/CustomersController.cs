using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeksaHDashboard.Models;

public class CustomerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Customers
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/Customer"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<IEnumerable<CustomersViewModel>>(jsonString);
            return View(customers);
        }

        return View(new List<CustomersViewModel>()); // Return an empty list on error
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomersViewModel customers)
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI");
        var response = await client.PostAsJsonAsync("api/Customer", customers);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }

        return View(customers); // If model is invalid, return the form with validation errors
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI");
        var response = await client.GetAsync($"api/Customer/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomersViewModel>(jsonString);
            return View(customers);
        }

        return NotFound(); // Handle case where customer is not found
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CustomersViewModel customers)
    {
        if (id != customers.Id)
        {
            return BadRequest(); // Ensure the customer ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("CustomersAPI");
            var response = await client.PutAsJsonAsync($"api/Customer/{id}", customers);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(customers); // If model is invalid, return the form with validation errors
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI");
        var response = await client.GetAsync($"api/Customer/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomersViewModel>(jsonString);
            return View(customers); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where customer is not found
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI");
        var response = await client.DeleteAsync($"api/Customer/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }

    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomersAPI");
        var response = await client.GetAsync($"api/Customer/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customers = JsonConvert.DeserializeObject<CustomersViewModel>(jsonString);
            return View(customers);
        }

        return NotFound(); // Handle the case where the customer is not found
    }
}

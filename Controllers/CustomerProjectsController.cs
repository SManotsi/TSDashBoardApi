using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TeksaHDashboard.Models;

public class CustomerPController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerPController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Customers
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/CustomerP"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customerProjects = JsonConvert.DeserializeObject<IEnumerable<CustomerProjectsViewModel>>(jsonString);
            return View(customerProjects);
        }

        return View(new List<CustomerProjectsViewModel>()); // Return an empty list on error
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CustomerProjectsViewModel customerProjects)
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
        var response = await client.PostAsJsonAsync("api/CustomerP", customerProjects);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }

        return View(customerProjects); // If model is invalid, return the form with validation errors
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
        var response = await client.GetAsync($"api/CustomerP/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customerProjects = JsonConvert.DeserializeObject<CustomerProjectsViewModel>(jsonString);
            return View(customerProjects);
        }

        return NotFound(); // Handle case where customer is not found
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CustomerProjectsViewModel customerProjects)
    {
        if (id != customerProjects.Id)
        {
            return BadRequest(); // Ensure the customer ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
            var response = await client.PutAsJsonAsync($"api/CustomerP/{id}", customerProjects);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(customerProjects); // If model is invalid, return the form with validation errors
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
        var response = await client.GetAsync($"api/CustomerP/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customerProjects = JsonConvert.DeserializeObject<CustomerProjectsViewModel>(jsonString);
            return View(customerProjects); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where customer is not found
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
        var response = await client.DeleteAsync($"api/CustomerP/{id}");

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }

    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("CustomerProjectsAPI");
        var response = await client.GetAsync($"api/CustomerP/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var customerProjects = JsonConvert.DeserializeObject<CustomerProjectsViewModel>(jsonString);
            return View(customerProjects);
        }

        return NotFound(); // Handle the case where the customer is not found
    }
}

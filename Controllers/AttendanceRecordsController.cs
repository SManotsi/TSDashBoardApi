using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class AttendanceRecordController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AttendanceRecordController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI"); // Use the named HttpClient
        var response = await client.GetAsync("api/AttendanceRecord"); // Use relative path since base URL is configured

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var attendanceRecords = JsonConvert.DeserializeObject<IEnumerable<AttendanceRecordsViewModel>>(jsonString);
            return View(attendanceRecords);
        }

        // If API call fails, return an empty list or handle error accordingly
        return View(new List<AttendanceRecordsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); // Return the Create view with an empty form
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AttendanceRecordsViewModel attendanceRecords)
    {

        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
        var response = await client.PostAsJsonAsync("api/AttendanceRecord", attendanceRecords); // Send POST request to create meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
        }


        return View(attendanceRecords); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
        var response = await client.GetAsync($"api/AttendanceRecord/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var attendanceRecords = JsonConvert.DeserializeObject<AttendanceRecordsViewModel>(jsonString);
            return View(attendanceRecords);
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AttendanceRecordsViewModel attendanceRecords)
    {
        if (id != attendanceRecords.Id)
        {
            return BadRequest(); // Ensure the meeting ID is consistent
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
            var response = await client.PutAsJsonAsync($"api/AttendanceRecord/{id}", attendanceRecords); // Send PUT request to update meeting

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }
        }

        return View(attendanceRecords); // If model is invalid, return the form with validation errors
    }
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
        var response = await client.GetAsync($"api/AttendanceRecord/{id}");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var attendanceRecords = JsonConvert.DeserializeObject<AttendanceRecordsViewModel>(jsonString);
            return View(attendanceRecords); // Return the Delete confirmation view
        }

        return NotFound(); // Handle case where meeting is not found
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
        var response = await client.DeleteAsync($"api/aAtendanceRecord/{id}"); // Send DELETE request to remove the meeting

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index)); // Redirect to Index after successful deletion
        }

        return NotFound(); // Handle case where deletion fails
    }
    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("AttendanceRecordsAPI");
        var response = await client.GetAsync($"api/AttendanceRecord/{id}"); // Fetch meeting by ID

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var attendanceRecords = JsonConvert.DeserializeObject<AttendanceRecordsViewModel>(jsonString);
            return View(attendanceRecords);
        }

        return NotFound(); // Handle the case where the meeting is not found
    }
    //  var response = await client.GetAsync($"api/meetings/{id}"); // Fetch meeting by ID
}



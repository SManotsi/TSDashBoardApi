using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeksaHDashboard.Models;

public class MeetingParticipantController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MeetingParticipantController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // GET: Meetings
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.GetAsync("api/MeetingParticipant");

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meetingParticipants = JsonConvert.DeserializeObject<IEnumerable<MeetingParticipantsViewModel>>(jsonString);
            return View(meetingParticipants);
        }

        return View(new List<MeetingParticipantsViewModel>());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MeetingParticipantsViewModel meetingParticipants)
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.PostAsJsonAsync("api/MeetingParticipant", meetingParticipants);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(meetingParticipants);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.GetAsync($"api/MeetingParticipant/{id}"); // Corrected to use consistent casing

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meetingParticipants = JsonConvert.DeserializeObject<MeetingParticipantsViewModel>(jsonString);
            return View(meetingParticipants);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MeetingParticipantsViewModel meetingParticipants)
    {
        if (id != meetingParticipants.Id)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
            var response = await client.PutAsJsonAsync($"api/MeetingParticipant/{id}", meetingParticipants);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        return View(meetingParticipants);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.GetAsync($"api/MeetingParticipant/{id}"); // Corrected to use consistent casing

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meetingParticipants = JsonConvert.DeserializeObject<MeetingParticipantsViewModel>(jsonString);
            return View(meetingParticipants);
        }

        return NotFound();
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.DeleteAsync($"api/MeetingParticipant/{id}"); // Corrected to use consistent casing

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }

        return NotFound();
    }

    public async Task<IActionResult> Details(int id)
    {
        var client = _httpClientFactory.CreateClient("MeetingParticipantsAPI");
        var response = await client.GetAsync($"api/MeetingParticipant/{id}"); // Corrected to use consistent casing

        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            var meetingParticipants = JsonConvert.DeserializeObject<MeetingParticipantsViewModel>(jsonString);
            return View(meetingParticipants);
        }

        return NotFound();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register HttpClient for dependency injection
builder.Services.AddHttpClient("MeetingsAPI", client =>

{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your API
});

builder.Services.AddHttpClient("CustomersAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("CustomerProjectsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("DepartmentsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("DocumentsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("EmployeeDepartmentsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("EmployeesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("EmployeeTrainingsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("ExpensesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("FinancialsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("InvoicesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("LeavesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("MeetingParticipantsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("ParticipantsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("PaymentsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("PerformanceReviewsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("ProjectsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("ReportsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("SupportTicketsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("TasksAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("TimeTrackingAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("TrainingProgramsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("TransactionsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("UsersAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("ActivitiesAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("AnnouncementsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("AttendanceRecordsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

builder.Services.AddHttpClient("BudgetsAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7194/"); // Set the base URL for your Customers API
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

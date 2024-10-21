using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using TSDashBoardApi.Application.Services;
using TSDashBoardApi.Infrastructure.Repositories;
using TSDashBoardApi.Application;
using TSDashBoardApi.Core.Repository;
using TSDashBoardApi.Infrastructure;
using TSDashBoardApi.Core.Domain;
using FluentAssertions.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register generic repository and services
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IActivitiesService, ActivitiesService>();
builder.Services.AddScoped<IAnnouncementsService, AnnouncementsService>();
builder.Services.AddScoped<IAttendanceRecordsService, AttendanceRecordsService>();
builder.Services.AddScoped<IBudgetsService, BudgetsService>();
builder.Services.AddScoped<ICustomerProjectsService, CustomerProjectsService>();
builder.Services.AddScoped<ICustomersService, CustomersService>();
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
builder.Services.AddScoped<IDocumentsService, DocumentsService>();
builder.Services.AddScoped<IEmployeeDepartmentsService, EmployeeDepartmentsService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddScoped<IEmployeeTrainingService, EmployeeTrainingsService>();
builder.Services.AddScoped<IExpensesService, ExpensesService>();
builder.Services.AddScoped<IFinancialsService, FinancialsService>();
builder.Services.AddScoped<ILeavesService, LeavesService>();
//builder.Services.AddScoped<IInvoicesService, IInvoicesService>();
builder.Services.AddScoped<IMeetingParticipantsService, MeetingParticipantsService>();
builder.Services.AddScoped<IMeetingsService, MeetingsService>();
builder.Services.AddScoped<IParticipantsService, ParticipantsService>();
builder.Services.AddScoped<IPaymentsService, PaymentsService>();
builder.Services.AddScoped<IPerformanceReviewsService, PerformanceReviewsService>();
builder.Services.AddScoped<IProjectsService, ProjectsService>();
builder.Services.AddScoped<ISupportTicketsService, SupportTicketsService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITimeTrackingService, TimeTrackingService>();
builder.Services.AddScoped<ITrainingProgramsService, TrainingProgramsService>();
builder.Services.AddScoped<ITransactionsService, TransactionsService>();
builder.Services.AddScoped<IUsersService, UsersService>();


// Add authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("https://localhost:7179/")
              .AllowAnyMethod()
              .AllowAnyHeader();

    });

});

//My Additional Info


// Other service configurations...

// Register IEmailService and IDocumentsService in the DI container
builder.Services.AddScoped<IEmailService>(provider =>
    new EmailService("smtp.gmail.com", 587, "smanotsi@gmail.com", "#Servant1"));

builder.Services.AddScoped<IDocumentsService, DocumentsService>();


// Other configurations...

//The End

// Add controllers
builder.Services.AddControllers();

    // Configure Swagger/OpenAPI
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowMvcApp");
    app.UseHttpsRedirection();

    app.UseAuthentication(); // Make sure to use authentication middleware
    app.UseAuthorization();

    app.MapControllers();

    app.Run();



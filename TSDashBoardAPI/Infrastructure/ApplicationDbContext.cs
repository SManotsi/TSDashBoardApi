using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TSDashBoardApi.Core.Domain;

namespace TSDashBoardApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Activities> Activities { get; set; }
        public DbSet<Announcements> Announcements { get; set; }
        public DbSet<AttendanceRecords> AttendanceRecords { get; set; }
        public DbSet<Budgets> Budgets { get; set; }
        public DbSet<CustomerProjects> CustomerProjects { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<EmployeeDepartments> EmployeeDepartments { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeTraining> EmployeeTraining { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Financials> Financials { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Leaves> Leaves { get; set; }
        public DbSet<MeetingParticipants> MeetingParticipants { get; set; }
        public DbSet<Meetings> Meetings { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PerformanceReviews> PerformanceReviews { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<SupportTickets> SupportTickets { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TimeTracking> TimeTracking { get; set; }
        public DbSet<TrainingPrograms> TrainingPrograms { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Users> Users { get; set; }




        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

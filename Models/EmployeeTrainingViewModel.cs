﻿namespace TeksaHDashboard.Models
{
    public class EmployeeTrainingViewModel
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? TrainingId { get; set; }
        public int? CompletionDate { get; set; }
        public required string Status { get; set; }
    }
}

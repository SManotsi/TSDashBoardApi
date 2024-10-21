namespace TSDashBoardApi.Core.Domain
{
    public class TrainingPrograms
    {
        public required int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required DateOnly DateScheduled { get; set; }
        public required Decimal DurationHours { get; set; }
    }
}

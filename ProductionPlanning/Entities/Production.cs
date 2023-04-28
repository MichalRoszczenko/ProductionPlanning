namespace ProductionPlanning.Entities
{
    public class Production
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ProductionTimeInHours { get; set; }
    }
}

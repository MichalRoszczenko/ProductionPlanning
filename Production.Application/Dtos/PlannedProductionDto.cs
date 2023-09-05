namespace Production.Application.Dtos
{
    public class PlannedProductionDto
    {
        public int ProductionId { get; set; }
        public DateTime StartProduction { get; set; }
        public DateTime EndProduction { get; set; }
    }
}

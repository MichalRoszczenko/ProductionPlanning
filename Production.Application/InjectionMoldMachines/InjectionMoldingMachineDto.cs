using Production.Application.Productions;

namespace Production.Application.InjectionMoldMachines
{
    public class InjectionMoldingMachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Online { get; set; }
        public int Tonnage { get; set; }
        public string Size { get; set; } = default!;
        public List<PlannedProductionDto>? PlannedProductions { get; set; }
    }
}
using System.Data;
using System.Data.SqlTypes;

namespace Production.Application.Production
{
    public class ProductionDtoInput
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid InjectionMoldId { get; set; } = default!;
        public int InjectionMoldingMachineId { get; set; } = default!;
    }
}

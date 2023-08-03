using Production.Domain.Entities;

namespace Production.Application.Material
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Cost { get; set; }
    }
}

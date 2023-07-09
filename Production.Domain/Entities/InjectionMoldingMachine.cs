namespace Production.Domain.Entities
{
    public class InjectionMoldingMachine
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Online { get; set; }
        public int Tonnage { get; set; }
        public string Size { get; set; } = default!;
        public List<Production>? Productions { get; set; }
    }
}

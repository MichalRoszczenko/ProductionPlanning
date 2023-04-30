namespace ProductionPlanning.Entities
{
    public class InjectionMoldingMachine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Online { get; set; }
        public int Tonnage { get; set; }
        public string Size { get; set; }
        public List<Production> Productions { get; set; } = new List<Production>();
    }
}

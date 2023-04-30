namespace ProductionPlanning.Entities
{
    public class InjectionMold
    {
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public string Producer { get; set; }
        public string Size { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Production> Productions { get; set; } = new List<Production>();
        public Material Material { get; set; }
    }
}

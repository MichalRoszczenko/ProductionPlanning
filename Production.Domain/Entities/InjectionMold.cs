namespace Production.Domain.Entities
{
    public class InjectionMold
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public string Size { get; set; } = default!;
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<Production> Productions { get; set; } = new List<Production>();
        public Material? Material { get; set; }
    }
}

namespace Production.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Count { get; set; }
        public InjectionMold? InjectionMold { get; set; }
        public Guid InjectionMoldId { get; set; }
    }
}

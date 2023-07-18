namespace Production.Application.InjectionMolds
{
    public class InjectionMoldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Producer { get; set; } = default!;
        public string Size { get; set; } = default!;
    }
}

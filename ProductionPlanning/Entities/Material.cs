﻿namespace ProductionPlanning.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Cost { get; set; }
        public InjectionMold? InjectionMold { get; set; }
        public Guid InjectionMoldId { get; set; }
    }
}

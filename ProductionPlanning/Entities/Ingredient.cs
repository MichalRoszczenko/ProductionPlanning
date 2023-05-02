﻿namespace ProductionPlanning.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public InjectionMold InjectionMold { get; set; }
        public Guid InjectionMoldId { get; set; }
    }
}

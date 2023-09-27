﻿namespace KotorsGate.Domain.Entities.Ability.Attribute
{
    public class Attribute
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Attribute() { }
    }
}

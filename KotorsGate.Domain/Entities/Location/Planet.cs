﻿namespace KotorsGate.Domain.Entities.Location
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public Planet() { }
    }
}

﻿namespace KotorsGate.Domain.Entities.Location
{
    public class LocationMap
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int AdjacentLocationId { get; set; }

        public LocationMap() { }
    }
}

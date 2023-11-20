namespace KotorsGate.Domain.Entities.Locations
{
    public class LocationMap
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int AdjacentLocationId { get; set; }

        public Location Location { get; set; }

        public LocationMap() {
            this.Location = new Location();
        }
    }
}

namespace KotorsGate.Domain.Entities.Locations
{
    public class LocationSquare
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public bool IsTraversable { get; set; } = false;

        public Location Location { get; set; }

        public LocationSquare() {
            this.Location = new Location();
        }
    }
}

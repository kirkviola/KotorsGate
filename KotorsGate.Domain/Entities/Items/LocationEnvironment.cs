using KotorsGate.Domain.Entities.Locations;

namespace KotorsGate.Domain.Entities.Items
{
    public class LocationEnvironment
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public LocationEnvironment() {
            Location = new Location();
        }
    }
}

namespace KotorsGate.Domain.Entities.Locations
{
    public class Battlefield
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public virtual ICollection<BattlefieldSquare> BattlefieldSquares { get; set; }

        public Battlefield() {
            this.Location = new Location();
            this.BattlefieldSquares = new List<BattlefieldSquare>();
        }
    }
}

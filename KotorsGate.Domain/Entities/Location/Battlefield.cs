namespace KotorsGate.Domain.Entities.Location
{
    public class Battlefield
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public Location Location { get; set; }

        public virtual IEnumerable<BattlefieldSquare> BattlefieldSquares { get; set; }

        public Battlefield() {
            this.Location = new Location();
            this.BattlefieldSquares = new List<BattlefieldSquare>();
        }
    }
}

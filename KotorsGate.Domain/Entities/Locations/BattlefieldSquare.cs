namespace KotorsGate.Domain.Entities.Locations
{
    public class BattlefieldSquare
    {
        public int Id { get; set; }
        public int BattlefieldId { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public Battlefield Battlefield { get; set; }

        public BattlefieldSquare() {
            this.Battlefield = new Battlefield();
        }
    }
}

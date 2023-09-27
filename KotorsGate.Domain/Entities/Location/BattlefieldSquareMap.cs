namespace KotorsGate.Domain.Entities.Location
{
    public class BattlefieldSquareMap
    {
        public int Id { get; set; }
        public int BattlefieldSquareId { get; set; }
        public int? UpSquareId { get; set; }
        public int? DownSquareId { get; set; }
        public int? LeftSquareId { get;set; }
        public int? RightSquareId { get; set; }

        public BattlefieldSquareMap() { }
    }
}

namespace KotorsGate.Domain.Entities.Ability.Power
{
    public class ClassPower
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int PowerId { get; set; }

        public Class Class { get; set; }
        public Power Power { get; set; }

        public ClassPower() 
        {
            Class = new Class();
            Power = new Power();
        }
    }
}

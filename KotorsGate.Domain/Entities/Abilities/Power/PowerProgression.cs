namespace KotorsGate.Domain.Entities.Abilities.Power
{
    public class PowerProgression
    {
        public int Id { get; set; }
        public int RequiredPowerId { get; set; }
        
        public Power Power { get; set; }
        public PowerProgression() 
        { 
            Power = new Power();
        }
    }
}

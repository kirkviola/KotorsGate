namespace KotorsGate.Domain.Entities.Ability.Power
{
    public class PowerProgression
    {
        public int Id { get; set; }
        public int RequiredPowerId { get; set; }
        
        public PowerProgression() { }
    }
}

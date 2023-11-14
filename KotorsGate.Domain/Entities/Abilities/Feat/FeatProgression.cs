namespace KotorsGate.Domain.Entities.Abilities.Feat
{
    public class FeatProgression
    {
        public int Id { get; set; }
        public int RequiredFeatId { get; set; }

        public Feat Feat { get; set; }

        public FeatProgression() 
        { 
            Feat = new Feat();
        }
    }
}

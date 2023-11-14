namespace KotorsGate.Domain.Entities.Abilities.Feat
{
    public class ClassFeat
    {
        public int Id { get; set; }
        public int FeatId { get; set; }
        public int ClassId { get; set; }

        public Class Class { get; set; }
        public Feat Feat { get; set; }
        public ClassFeat() 
        { 
            Class = new Class();
            Feat = new Feat();
        }
    }
}

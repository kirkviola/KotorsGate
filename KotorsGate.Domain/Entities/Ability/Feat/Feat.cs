namespace KotorsGate.Domain.Entities.Ability.Feat
{
    public class Feat
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ToolTip { get; set; } = string.Empty;
        public int RequiredLevel { get; set; }

        public Feat() { }
    }
}

namespace KotorsGate.Domain.Entities.Items
{
    public class EnvironmentObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int SkillValue { get; set; }
        public string SkillName { get; set; } = string.Empty;

        public EnvironmentObject() { }
    }
}

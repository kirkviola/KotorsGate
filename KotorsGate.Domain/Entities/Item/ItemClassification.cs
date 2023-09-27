using KotorsGate.Domain.Constants;

namespace KotorsGate.Domain.Entities.Item
{
    public class ItemClassification
    {
        public int Id { get; set; }
        public ItemType Name { get; set; }

        public ItemClassification() { }
    }
}

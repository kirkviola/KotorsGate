using KotorsGate.Domain.Constants;

namespace KotorsGate.Domain.Entities.Items
{
    public class ItemClassification
    {
        public int Id { get; set; }
        public ItemType Name { get; set; }

        public virtual IEnumerable<Item> Items { get; set; }

        public ItemClassification() { }
    }
}

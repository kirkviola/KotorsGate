using KotorsGate.Domain.Entities.Characters;

namespace KotorsGate.Domain.Entities.Items
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsConsumable { get; set; }
        public int ItemTypeId { get; set; }

        public virtual IEnumerable<ItemAttribute> ItemAttributes { get; set; }
        public virtual IEnumerable<CharacterItem>? CharacterItems { get; set; }

        public ItemClassification ItemClassification { get; set; }

        public Item() { }
    }
}

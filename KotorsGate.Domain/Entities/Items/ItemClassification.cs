namespace KotorsGate.Domain.Entities.Items
{
    public class ItemClassification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public ItemClassification() { }
    }
}

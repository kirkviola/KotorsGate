namespace KotorsGate.Domain.Entities.Item
{
    public class ItemAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public int? SingleValue { get; set; }
        public int ItemId { get; set; }

        public ItemAttribute() { }

    }
}

namespace KotorsGate.Domain.Constants
{
    public sealed class ItemType
    {
        public static readonly ItemType Medpack = new ItemType("Medpack");
        public static readonly ItemType Stim = new ItemType("Stimulant");
        public static readonly ItemType Lightsaber = new ItemType("One-handed Lightsaber");
        public static readonly ItemType ShortLightsaber = new ItemType("Short Lightsaber");
        public static readonly ItemType DoubleSaber = new ItemType("Double-bladed Lightsaber");
        public static readonly ItemType Shortsword = new ItemType("Short Sword");
        public static readonly ItemType Longsword = new ItemType("Long Sword");
        public static readonly ItemType DoubleSword = new ItemType("Double-sided sword");
        public static readonly ItemType Pistol = new ItemType("Blaster Pistol");
        public static readonly ItemType Rifle = new ItemType("Blaster Rifle");
        public static readonly ItemType ChestArmor = new ItemType("Chest Armor");
        public static readonly ItemType HeadArmor = new ItemType("Head Gear");
        public static readonly ItemType Gloves = new ItemType("Gloves");
        public static readonly ItemType Belt = new ItemType("Belt");
        public static readonly ItemType WristArmor = new ItemType("Wrist Armor");
        public static readonly ItemType Implant = new ItemType("Implant");
        public static readonly ItemType QuestItem = new ItemType("Quest Item");
        private ItemType(string value)
        {
            Value = value;
        }

         public string Value { get; private set; }
    }
}

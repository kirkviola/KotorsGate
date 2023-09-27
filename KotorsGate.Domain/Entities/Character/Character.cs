﻿namespace KotorsGate.Domain.Entities.Character
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public int TotalHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }
        public int? TotalForcePoints { get; set; }
        public int? CurrentForcePoints { get; set; }
        public int Alignment { get; set; }

        public Character() { }

    }
}

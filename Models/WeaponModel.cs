namespace CharacterSheet.Models
{
    public class WeaponModel
    {
        public string Name { get; set; } = string.Empty;
        public WeaponData.Range Range { get; set; }
        public Skill? Skill { get; set; }
        public int? Damage { get; set; }
        public int? Critical { get; set; }
        public List<string> Qualities { get; set; } = [];

        public string RangeAbbreviation => Range switch
        {
            WeaponData.Range.Engaged => "E",
            WeaponData.Range.Short => "S",
            WeaponData.Range.Medium => "M",
            WeaponData.Range.Long => "L",
            WeaponData.Range.Extreme => "X",
            _ => string.Empty,
        };
    }

    public static class WeaponData
    {
        public enum Range
        {
            Empty,
            Engaged,
            Short,
            Medium,
            Long,
            Extreme
        }

        public static readonly string[] Qualities =
        [
            "Accurate",
            "Auto-Fire",
            "Blast",
            "Breach",
            "Burn",
            "Concussive",
            "Cortosis",
            "Cumbersome",
            "Defensive",
            "Deflection",
            "Disorient",
            "Ensnare",
            "Guided",
            "Inaccurate",
            "Inferior",
            "Ion",
            "Knockdown",
            "Limited Ammo",
            "Linked",
            "Modular",
            "Pierce",
            "Prepare",
            "Slow-Firing",
            "Stun",
            "Stun Damage",
            "Stun Setting",
            "Sunder",
            "Superior",
            "Tractor",
            "Unwieldy",
            "Vicious"
        ];

        public static readonly string[] Mods =
        [
            "Cortosis Rounds",
            "Dual-Phase",
            "Forearm Grip",
            "Mono-Molecular Edge",
            "Multi-optic Sight",
            "Refined Cortosis",
            "Serrated Edge",
            "Telescopic Optical Sight",
            "Weapon Sling"
        ];
    }
}

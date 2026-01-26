using CharacterSheet.Components;

namespace CharacterSheet.Models
{
    public class CharacterModel
    {
        //Serialization constructor
        public CharacterModel()
        {

        }

        public CharacterModel(bool initializer)
        {
            Skills = 
            [
                new Skill("Astrogation", Intellect),
                new Skill("Athletics", Brawn),
                new Skill("Charm", Presence),
                new Skill("Coercion", Willpower),
                new Skill("Computers", Intellect),
                new Skill("Cool", Presence),
                new Skill("Coordination", Agility),
                new Skill("Cybernetics", Intellect),
                new Skill("Deception", Cunning),
                new Skill("Discipline", Willpower),
                new Skill("Leadership", Presence),
                new Skill("Mechanics", Intellect),
                new Skill("Medicine", Intellect),
                new Skill("Negotiation", Presence),
                new Skill("Perception", Cunning),
                new Skill("Piloting-Planetary", Agility),
                new Skill("Piloting-Space", Agility),
                new Skill("Resilience", Brawn),
                new Skill("Skulduggery", Cunning),
                new Skill("Stealth", Agility),
                new Skill("Streetwise", Cunning),
                new Skill("Survival", Cunning),
                new Skill("Vigilance", Willpower),

                new Skill("Brawl", Brawn, Skill.SkillType.Combat),
                new Skill("Gunnery", Agility, Skill.SkillType.Combat),
                new Skill("Lightsaber", Brawn, Skill.SkillType.Combat),
                new Skill("Melee", Brawn, Skill.SkillType.Combat),
                new Skill("Ranged-Heavy", Agility, Skill.SkillType.Combat),
                new Skill("Ranged-Light", Agility, Skill.SkillType.Combat),

                new Skill("Core Worlds", Intellect, Skill.SkillType.Knowledge),
                new Skill("Education", Intellect, Skill.SkillType.Knowledge),
                new Skill("Lore", Intellect, Skill.SkillType.Knowledge),
                new Skill("Outer Rim", Intellect, Skill.SkillType.Knowledge),
                new Skill("Underworld", Intellect, Skill.SkillType.Knowledge),
                new Skill("Warfare", Intellect, Skill.SkillType.Knowledge),
                new Skill("Xenology", Intellect, Skill.SkillType.Knowledge),
            ];
        }

        public string CharacterName { get; set; } = string.Empty;
        public string PlayerName { get; set; } = string.Empty;
        public string Career { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;

        public Characteristic Brawn { get; set; } = new Characteristic(nameof(Brawn));
        public Characteristic Agility { get; set; } = new Characteristic(nameof(Agility));
        public Characteristic Intellect { get; set; } = new Characteristic(nameof(Intellect));
        public Characteristic Cunning { get; set; } = new Characteristic(nameof(Cunning));
        public Characteristic Willpower { get; set; } = new Characteristic(nameof(Willpower));
        public Characteristic Presence { get; set; } = new Characteristic(nameof(Presence));

        public int Soak { get; set; }
        public int WoundThreshold { get; set; }
        public int StrainThreshold { get; set; }
        public int DefenseRanged { get; set; }
        public int DefenseMelee { get; set; }

        public List<Skill> Skills { get; set; } = [];

        public State Current { get; set; } = new();
    }

    public class State
    {
        public int Wounds { get; set; }
        public int Strain { get; set; }
        public List<CriticalInjury> CriticalInjuries { get; set; } = [];
    }

    public class CriticalInjury
    {
        public string Name { get; set; } = string.Empty;
        public int Severity { get; set; }
    }

    public class Characteristic
    {
        //Serialization constructor
        public Characteristic()
        {
            
        }

        public Characteristic(string name)
        {
            Name = name;
            Abbreviation = name[..1];
        }

        public string Name { get; set; } = string.Empty;
        public string Abbreviation { get; set; }
        public int Value { get; set; }
    }

    public class Skill
    {
        //Serialization constructor
        public Skill()
        {
            
        }

        public Skill(string name, Characteristic baseChar, SkillType type = SkillType.General)
        {
            Base = baseChar;
            Name = name;
            Type = type;
        }

        public Characteristic Base { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Ranks { get; set; }
        public bool IsCareerSkill { get; set; }
        public SkillType Type { get; set; }

        public int BonusDice { get; set; }
        public int SetbackCancels { get; set; }

        public enum SkillType
        {
            General,
            Combat,
            Knowledge
        }

        public List<Die.DieType> GenerateDicePool()
        {
            if(Ranks < 0)
            {
                return [];
            }
            var dicePool = new List<Die.DieType>();
            int yellows;
            int greens;
            if(Ranks <= Base.Value)
            {
                yellows = Ranks;
                greens = Base.Value - Ranks;
            }
            else
            {
                yellows = Base.Value;
                greens = Ranks - Base.Value;
            }

            for(var i = 0; i < yellows; ++i)
            {
                dicePool.Add(Die.DieType.Proficiency);
            }
            for(var i = 0; i < greens; ++i)
            {
                dicePool.Add(Die.DieType.Ability);
            }

            for(var i = 0; i < BonusDice; ++i)
            {
                dicePool.Add(Die.DieType.Boost);
            }
            for(var i = 0; i < SetbackCancels; ++i)
            {
                dicePool.Add(Die.DieType.Setback);
            }

            return dicePool;
        }
    }
}

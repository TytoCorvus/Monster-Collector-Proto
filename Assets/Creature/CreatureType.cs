using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureType
{
    public static Dictionary<Name, CreatureType> creatureTypes = new Dictionary<Name, CreatureType>();
    public static Dictionary<string, CreatureType> creatureTypesByName = new Dictionary<string, CreatureType>();

    public readonly static CreatureType VITAL;
    public readonly static CreatureType EARTH;
    public readonly static CreatureType FLAME;
    public readonly static CreatureType FROST;
    public readonly static CreatureType AQUA;
    public readonly static CreatureType NATURE;
    public readonly static CreatureType SPECTRE;
    public readonly static CreatureType VENOM;
    public readonly static CreatureType SKY;
    public readonly static CreatureType STORM;
    public readonly static CreatureType METAL;
    public readonly static CreatureType ELDER;
    public readonly static CreatureType ALPHA;

    public readonly int id;

    public readonly string name;

    public readonly string color;

    public readonly HashSet<Name> advantage;

    public readonly HashSet<Name> resist;

    public readonly HashSet<Name> immune;

    static CreatureType()
    {
        HashSet<Name> empty = new HashSet<Name>();

        VITAL   = new CreatureType(0, "Vital", "7e8f7c", 
                new HashSet<Name>(new Name[] {Name.FROST, Name.ELDER}), 
                new HashSet<Name>(new Name[] {}),
                empty);
        EARTH   = new CreatureType(1, "Earth", "a1771f", 
				new HashSet<Name>(new Name[] {Name.FLAME, Name.STORM}), 
				new HashSet<Name>(new Name[] {Name.FLAME, Name.VENOM, Name.SKY}), 
				new HashSet<Name>(new Name[] {Name.STORM}));
        FLAME   = new CreatureType(2, "Flame", "de3910", 
				new HashSet<Name>(new Name[] {Name.FROST, Name.NATURE, Name.VENOM, Name.METAL}), 
				new HashSet<Name>(new Name[] {Name.FLAME, Name.FROST, Name.NATURE, Name.VENOM, Name.STORM}), 
				empty);
        FROST   = new CreatureType(3, "Frost", "b2eff7", 
				new HashSet<Name>(new Name[] {Name.EARTH, Name.AQUA, Name.NATURE, Name.SKY, Name.METAL}), 
				new HashSet<Name>(new Name[] {Name.NATURE}),
                empty);
        AQUA    = new CreatureType(4, "Aqua", "23a4a6", 
				new HashSet<Name>(new Name[] {Name.EARTH, Name.FLAME, Name.METAL}), 
				new HashSet<Name>(new Name[] {Name.FLAME, Name.AQUA, Name.SKY, Name.METAL}),
                empty);
        NATURE  = new CreatureType(5, "Nature", "438f22", 
				new HashSet<Name>(new Name[] {Name.EARTH, Name.AQUA, Name.ELDER}), 
				new HashSet<Name>(new Name[] {Name.EARTH, Name.AQUA, Name.NATURE, Name.STORM, Name.ALPHA}),
                empty);
        SPECTRE = new CreatureType(6, "Spectre", "9c1182", 
				new HashSet<Name>(new Name[] {Name.SPECTRE, Name.ELDER}), 
				empty, 
				new HashSet<Name>(new Name[] {Name.VITAL, Name.VENOM}));
        VENOM   = new CreatureType(7, "Venom", "4d187a", 
				new HashSet<Name>(new Name[] {Name.VITAL, Name.NATURE, Name.ELDER, Name.ALPHA}), 
				new HashSet<Name>(new Name[] {Name.NATURE, Name.VENOM, Name.ALPHA}),
                empty);
        SKY     = new CreatureType(8, "Sky", "72dbed",
                new HashSet<Name>(new Name[] {Name.VITAL }), 
				new HashSet<Name>(new Name[] {Name.NATURE, Name.ELDER}), 
				new HashSet<Name>(new Name[] {Name.EARTH}));
        STORM   = new CreatureType(9, "Storm", "e7f03c", 
				new HashSet<Name>(new Name[] {Name.FROST, Name.AQUA, Name.SKY, Name.METAL}), 
				new HashSet<Name>(new Name[] {Name.STORM, Name.METAL}),
                empty);
        METAL   = new CreatureType(10, "Metal", "b2b3a4", 
				new HashSet<Name>(new Name[] {Name.FROST}), 
				new HashSet<Name>(new Name[] {Name.VITAL, Name.SPECTRE, Name.SKY, Name.ELDER, Name.METAL}), 
				new HashSet<Name>(new Name[] {Name.VENOM}));
        ELDER   = new CreatureType(11, "Elder", "1c4aed", 
				new HashSet<Name>(new Name[] {Name.EARTH, Name.FLAME, Name.FROST, Name.AQUA, Name.STORM}), 
				new HashSet<Name>(new Name[] {Name.VITAL, Name.SPECTRE, Name.VENOM, Name.ALPHA}),
                empty);
        ALPHA   = new CreatureType(12, "Alpha", "e88205", 
				new HashSet<Name>(new Name[] {Name.VITAL, Name.SPECTRE, Name.ELDER, Name.ALPHA}), 
				new HashSet<Name>(new Name[] {Name.NATURE, Name.SPECTRE, Name.ELDER}),
                empty);

        creatureTypes.Add(Name.VITAL, VITAL);
        creatureTypes.Add(Name.EARTH, EARTH);
        creatureTypes.Add(Name.FLAME, FLAME);
        creatureTypes.Add(Name.FROST, FROST);
        creatureTypes.Add(Name.AQUA, AQUA);
        creatureTypes.Add(Name.NATURE, NATURE);
        creatureTypes.Add(Name.SPECTRE, SPECTRE);
        creatureTypes.Add(Name.VENOM, VENOM);
        creatureTypes.Add(Name.SKY, SKY);
        creatureTypes.Add(Name.STORM, STORM);
        creatureTypes.Add(Name.METAL, METAL);
        creatureTypes.Add(Name.ELDER, ELDER);
        creatureTypes.Add(Name.ALPHA, ALPHA);

        creatureTypesByName.Add(VITAL.name, VITAL);
        creatureTypesByName.Add(EARTH.name, EARTH);
        creatureTypesByName.Add(FLAME.name, FLAME);
        creatureTypesByName.Add(FROST.name, FROST);
        creatureTypesByName.Add(AQUA.name, AQUA);
        creatureTypesByName.Add(NATURE.name, NATURE);
        creatureTypesByName.Add(SPECTRE.name, SPECTRE);
        creatureTypesByName.Add(VENOM.name, VENOM);
        creatureTypesByName.Add(SKY.name, SKY);
        creatureTypesByName.Add(STORM.name, STORM);
        creatureTypesByName.Add(METAL.name, METAL);
        creatureTypesByName.Add(ELDER.name, ELDER);
        creatureTypesByName.Add(ALPHA.name, ALPHA);
    }

    private CreatureType(int id, string name, string color, HashSet<Name> adv, HashSet<Name> res, HashSet<Name> imm)
    {
        this.id = id;
        this.name = name;
        this.color = color;
        this.advantage = adv;
        this.resist = res;
        this.immune = imm;
    }

    public double getDamageMultiplierVs(HashSet<CreatureType> creatureTypes)
    {
        int advantages = 0;
        int resists = 0;

        foreach (CreatureType ct in creatureTypes)
        {
            if (ct.immune.Contains((Name)id))
            {
                return 0;
            }
            if (ct.resist.Contains((Name)id))
            {
                resists++;
            }
            if (advantage.Contains((Name)ct.id))
            {
                advantages++;
            }
        }

        return (1 + advantages) / (1 + resists);
    }

    public bool Equals(CreatureType other)
    {
        return other.id == id;
    }

    public enum Name
    {
        NONE = -1,
        VITAL = 0,
        EARTH = 1,
        FLAME = 2,
        FROST = 3,
        AQUA = 4,
        NATURE = 5,
        SPECTRE = 6,
        VENOM = 7,
        SKY = 8,
        STORM = 9,
        METAL = 10,
        ELDER = 11,
        ALPHA = 12
    }
}

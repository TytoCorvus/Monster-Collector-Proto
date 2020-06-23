using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureType
{
    public static Dictionary<Name, CreatureType> creatureTypes = new Dictionary<Name, CreatureType>();
    public static Dictionary<string, CreatureType> creatureTypesByName = new Dictionary<string, CreatureType>();

    public readonly static CreatureType VITAL;
    public readonly static CreatureType EARTH;
    public readonly static CreatureType HEAT;
    public readonly static CreatureType COLD;
    public readonly static CreatureType AQUA;
    public readonly static CreatureType NATURE;
    public readonly static CreatureType SPIRIT;
    public readonly static CreatureType VENOM;

    public readonly int id;

    public readonly string name;

    public readonly string color;

    public readonly HashSet<int> advantage;

    public readonly HashSet<int> resist;

    public readonly HashSet<int> immune;

    static CreatureType()
    {
        HashSet<int> empty = new HashSet<int>();

        VITAL =  new CreatureType(0, "Vital", "7e8f7c", empty, empty, empty);
        EARTH = new CreatureType(1, "Earth", "a1771f", empty, empty, empty);
        HEAT = new CreatureType(2, "Heat", "de3910", empty, empty, empty);
        COLD = new CreatureType(3, "Cold", "62a9c4", empty, empty, empty);
        AQUA = new CreatureType(4, "Aqua", "111199", empty, empty, empty);
        NATURE = new CreatureType(5, "Nature", "438f22", empty, empty, empty);
        SPIRIT = new CreatureType(6, "Spirit", "9c1182", empty, empty, empty);
        VENOM = new CreatureType(7, "Venom", "401261", empty, empty, empty);

        creatureTypes.Add(Name.VITAL, VITAL);
        creatureTypes.Add(Name.EARTH, EARTH);
        creatureTypes.Add(Name.HEAT, HEAT);
        creatureTypes.Add(Name.COLD, COLD);
        creatureTypes.Add(Name.AQUA, AQUA);
        creatureTypes.Add(Name.NATURE, NATURE);
        creatureTypes.Add(Name.SPIRIT, SPIRIT);
        creatureTypes.Add(Name.VENOM, VENOM);

        creatureTypesByName.Add(VITAL.name, VITAL);
        creatureTypesByName.Add(EARTH.name, EARTH);
        creatureTypesByName.Add(HEAT.name, HEAT);
        creatureTypesByName.Add(COLD.name, COLD);
        creatureTypesByName.Add(AQUA.name, AQUA);
        creatureTypesByName.Add(NATURE.name, NATURE);
        creatureTypesByName.Add(SPIRIT.name, SPIRIT);
        creatureTypesByName.Add(VENOM.name, VENOM);
    }

    private CreatureType(int id, string name, string color, HashSet<int> adv, HashSet<int> res, HashSet<int> imm)
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
            if (ct.immune.Contains(id))
            {
                return 0;
            }
            if (ct.resist.Contains(id))
            {
                resists++;
            }
            if (advantage.Contains(ct.id))
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
        HEAT = 2,
        COLD = 3,
        AQUA = 4,
        NATURE = 5,
        SPIRIT = 6,
        VENOM = 7
    }
}

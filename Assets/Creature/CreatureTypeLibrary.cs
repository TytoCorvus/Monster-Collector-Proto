using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureTypeLibrary
{
    public static Dictionary<CreatureTypeName, CreatureType> creatureTypes = new Dictionary<CreatureTypeName, CreatureType>();

    static CreatureTypeLibrary()
    {
        List<int> empty = new List<int>();
        creatureTypes.Add(CreatureTypeName.VITAL, new CreatureType(0, "Vital", "7e8f7c", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.EARTH, new CreatureType(1, "Earth", "a1771f", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.HEAT, new CreatureType(2, "Heat", "de3910", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.COLD, new CreatureType(3, "Cold", "62a9c4", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.AQUA, new CreatureType(4, "Aqua", "111199", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.NATURE, new CreatureType(5, "Nature", "438f22", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.SPIRIT, new CreatureType(6, "Spirit", "9c1182", empty, empty, empty));
        creatureTypes.Add(CreatureTypeName.VENOM, new CreatureType(7, "Venom", "401261", empty, empty, empty));
    }

    public enum CreatureTypeName
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

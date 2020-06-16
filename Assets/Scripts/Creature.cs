using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public readonly CreatureStats stats;
    public List<Move> moveset;
    public FocalPoints focalPoints;
    public List<CreatureType> creatureTypes { get => creatureTypes; set => creatureTypes = value; }

    public Creature(CreatureStats stats, List<CreatureType> creatureTypes)
    {
        this.stats = stats;
        this.creatureTypes = creatureTypes;
    }

    public CreatureStats getStats()
    {
        return stats;
    }
}

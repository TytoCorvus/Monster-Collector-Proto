using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public readonly CreatureStats stats;
    public List<Move> moveset;

    public Creature(CreatureStats stats)
    {
        this.stats = stats;
    }

    public CreatureStats getStats()
    {
        return stats;
    }
}

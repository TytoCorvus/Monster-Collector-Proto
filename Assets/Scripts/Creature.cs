using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : BattleActionSource
{

    public const int MAX_FOCUS = 100;
    public readonly CreatureStats stats;
    public List<Move> moveset;
    public int currentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int currentFocus
    {
        get { return currentFocus; }
        set { currentFocus = value > MAX_FOCUS ? MAX_FOCUS : value; }
    }

    public Creature(CreatureStats stats)
    {
        this.stats = stats;
        this.currentHP = stats.getStat(CreatureStats.StatName.HP).get();
    }

    public CreatureStats getStats()
    {
        return stats;
    }
}

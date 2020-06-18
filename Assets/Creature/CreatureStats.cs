using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats
{
    public Dictionary<StatName, Stat> stats = new Dictionary<StatName, Stat>();

    public CreatureStats(int hp, int str, int arm, int spd)
    {
        stats.Add(StatName.HP, new Stat(hp));
        stats.Add(StatName.STR, new Stat(str));
        stats.Add(StatName.ARM, new Stat(arm));
        stats.Add(StatName.SPD, new Stat(spd));
    }

    public Stat getStat(StatName statName)
    {
        return stats[statName];
    }

    public void setStatsToBase()
    {
        foreach (KeyValuePair<StatName, Stat> entry in stats)
        {
            entry.Value.setModifier(new StatModifier());
        }
    }
}

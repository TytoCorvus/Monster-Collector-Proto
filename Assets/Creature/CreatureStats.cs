﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats
{
    private readonly int hp;
    private readonly int str;
    private readonly int arm;
    private readonly int spd;

    public CreatureStats(){
        this.hp = 10;
        this.str = 10;
        this.arm = 10;
        this.spd = 10;
    }

    public CreatureStats(int hp, int str, int arm, int spd)
    {
        this.hp  = hp;
        this.str = str;
        this.arm = arm;
        this.spd = spd;
    }

    public CreatureStats(CreatureStats other)
    {
        this.hp = other.hp;
        this.str = other.str;
        this.arm = other.arm;
        this.spd = other.spd;

    }

    public int getStat(StatName statName)
    {
        switch (statName)
        {
            case StatName.HP:
                return hp;
            case StatName.STR:
                return str;
            case StatName.ARM:
                return arm;
            case StatName.SPD:
                return spd;
            default:
                return 0;
        }
    }

    public CreatureStats getStatsWithMods(List<Pair<StatName, StatModifier>> statMods)
    {
        StatModifier hpMod = StatModifier.NEUTRAL_MOD;
        StatModifier strMod = StatModifier.NEUTRAL_MOD;
        StatModifier armMod = StatModifier.NEUTRAL_MOD;
        StatModifier spdMod = StatModifier.NEUTRAL_MOD;

        foreach(Pair<StatName, StatModifier> mod in statMods)
        {
            switch (mod.getFirst())
            {
                case StatName.HP:
                    hpMod = hpMod.add(mod.getSecond());
                    break;
                case StatName.STR:
                    strMod = strMod.add(mod.getSecond());
                    break;
                case StatName.ARM:
                    armMod = armMod.add(mod.getSecond());
                    break;
                case StatName.SPD:
                    spdMod = spdMod.add(mod.getSecond());
                    break;
                default:
                    throw new System.Exception("CreatureStats was passed a stat name that it can't consider");
            }
        }

        return new CreatureStats(hpMod.applyToBase(hp), strMod.applyToBase(str), armMod.applyToBase(arm), spdMod.applyToBase(spd));
    }
}

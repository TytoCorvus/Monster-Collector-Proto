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

    public static class Stat
    {
        private readonly int baseVal;
        private readonly StatModifier modifier;
        public Stat(int baseVal)
        {
            this.baseVal = baseVal;
            this.modifier = new StatModifier();
        }

        public int getBase()
        {
            return baseVal;
        }

        public int get()
        {
            return (baseVal + modifier.getadditive()) * modifier.getmultiplicative();
        }
    }

    public static class StatModifier
    {
        private int additive
        {
            get { return additive; }
        }
        private double multiplicative
        {
            get { return multiplicative; }
        }

        public StatModifier()
        {
            this.additive = 0;
            this.multiplicative = 1;
        }

        public void applyAdditive(int additive)
        {
            additive += additive;
        }

        public void applyMultiplicative(double multiplicative)
        {
            multiplicative += multiplicative;
        }
    }

    public enum StatName
    {
        HP = 0,
        STR = 1,
        ARM = 2,
        SPD = 3
    }
}

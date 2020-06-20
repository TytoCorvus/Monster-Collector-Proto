using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CreatureStatTest
    {
        public CreatureStats testBase = new CreatureStats(100, 100, 100, 100);
        public StatModifier basicStatModifier = new StatModifier(0, 2);

        [Test]
        public void testBasicStatMod()
        {
            int baseVal = 10;
            StatModifier add = new StatModifier(5, 1);
            StatModifier mult = new StatModifier(0, 3);
            StatModifier both = new StatModifier(10, 2);
            Assert.That(add.applyToBase(baseVal) == 15);
            Assert.That(mult.applyToBase(baseVal) == 30);
            Assert.That(both.applyToBase(baseVal) == 40);
        }

        [Test]
        public void testAddStatModSimple()
        {
            int baseVal = 10;
            StatModifier add = new StatModifier(5, 1);
            StatModifier mult = new StatModifier(0, 10);
            StatModifier statModSum = add.add(mult);

            Assert.That(statModSum.applyToBase(baseVal) == 150);
        }

        [Test]
        public void testGetCreatureStatsWithMods()
        {
            List<Pair<StatName, StatModifier>> mods = new List<Pair<StatName, StatModifier>>();
            mods.Add(new Pair<StatName, StatModifier>(StatName.STR, new StatModifier(10, 1)));
            mods.Add(new Pair<StatName, StatModifier>(StatName.STR, new StatModifier(30, 2)));
            mods.Add(new Pair<StatName, StatModifier>(StatName.ARM, new StatModifier(0, 3)));
            mods.Add(new Pair<StatName, StatModifier>(StatName.SPD, new StatModifier(10, 0.5)));
            mods.Add(new Pair<StatName, StatModifier>(StatName.SPD, new StatModifier(-20, 0.25)));

            CreatureStats result = testBase.getStatsWithMods(mods);

            Assert.That(result.getStat(StatName.HP) == 100);
            Assert.That(result.getStat(StatName.STR) == 280);
            Assert.That(result.getStat(StatName.ARM) == 300);
            Assert.That(result.getStat(StatName.SPD) == (int)(90 * 0.5 * 0.25));
        }

    }
}

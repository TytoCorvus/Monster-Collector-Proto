using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class JSONDeserializationTest
    {

        [Test]
        public void testStatModifierDeserialization()
        {
            string json1 = "[0,1]";
            StatModifier expected1 = new StatModifier(0, 1);
            Assert.That(expected1.Equals(StatModifier.fromJSONObject(new JSONObject(json1))));

            string json2 = "[55, 0.67]";
            StatModifier expected2 = new StatModifier(55, 0.67);
            Assert.That(expected2.Equals(StatModifier.fromJSONObject(new JSONObject(json2))));
        }

       [Test]
       public void testCreatureStatsDeserialization()
        {
            string statsString = "[10, 2, 5, 6.0]";
            CreatureStats expected = new CreatureStats(10, 2, 5, 6);
            CreatureStats actual = CreatureStats.fromJSONObject(JSONObject.Create(statsString));
            Assert.That(expected.Equals(actual));
        }

        [Test]
        public void testCreatureFormDeserialization()
        {
            string form1 = "{"
           + "\"creatureTypes\":[\"Flame\"],"
           + "\"statMods\":{"
                + "\"STR\":[5, 1],"
                + "\"ARM\":[0, 2],"
                + "\"SPD\":[-40, .85] "
            + "},"
            + "\"moveId\":null,"
            + "\"abilityId\":1,"
            + "\"revealAction\":null"
        + "}";

            CreatureForm result = CreatureForm.fromJSONObject(JSONObject.Create(form1));

            List<Pair<StatName, StatModifier>> expectedMods = new List<Pair<StatName, StatModifier>>();
            expectedMods.Add(new Pair<StatName, StatModifier>(StatName.STR, new StatModifier(5, 1)));
            expectedMods.Add(new Pair<StatName, StatModifier>(StatName.ARM, new StatModifier(0, 2)));
            expectedMods.Add(new Pair<StatName, StatModifier>(StatName.SPD, new StatModifier(-40, .85)));

            HashSet<CreatureType> creatureTypes = new HashSet<CreatureType>();
            creatureTypes.Add(CreatureType.creatureTypesByName["Flame"]);

            CreatureForm expected = new CreatureForm(creatureTypes, expectedMods, null, null, null);
            CreatureForm actual = CreatureForm.fromJSONObject(JSONObject.Create(form1));

            Assert.That(expected.Equals(actual));
        }

        [Test]
        public void testFocusPointDeserialization()
        {
            string focusPointString = "{\n\"description\":\"Small boost to speed\",\n\"statMods\":{\n\"SPD\":[5, 1]\n}\n}";
            FocusPoint actual = FocusPoint.fromJSONObject(JSONObject.Create(focusPointString));

            List<Pair<StatName, StatModifier>> statMods = new List<Pair<StatName, StatModifier>>();
            statMods.Add(new Pair<StatName, StatModifier>(StatName.SPD, new StatModifier(5,1)));

            FocusPoint expected = new FocusPoint(null, null, statMods, "Small boost to speed");
            Assert.That(actual.Equals(expected));
        }

        [Test]
        public void testCreatureDeserialization()
        {
            LibraryLoader.loadMoveLibrary();

            string creatureJSONString = "{\"creatureId\":1,\n\"creatureName\":\"\",\n\"baseStats\":[10,10,10,10],\n\"abilityId\":1,\n\"moves\":[\"Strike\",\"Slam\"],\n\"focalPoints\":[\n{\n\"description\":\"Small boost to strength\",\n\"statMods\":{\n\"STR\":[5,1]\n}\n},\n{\n\"description\":\"Small boost to armor\",\n\"statMods\":{\n\"ARM\":[5, 1]\n}\n},\n{\n\"description\":\"Additional armor scaling\",\n\"statMods\":{\n\"ARM\":[0, 1.1]\n}\n},\n{\n\"description\":\"Small boost to speed\",\n\"statMods\":{\n\"SPD\":[5, 1]\n}\n}\n],\n\"baseForm\":{\n\"creatureTypes\":[\"Vital\"],\n\"abilityId\":1,\n\"revealAction\":null\n},\n\"availableForms\":[\n{\n\"creatureTypes\":[\"Flame\"],\n\"statMods\":{\n\"STR\":[5, 1],\n\"ARM\":[0, 1],\n\"SPD\":[0, 1]\n},\n\"moveId\":null,\n\"abilityId\":1,\n\"revealAction\":null\n}\n]\n}";
            JSONObject creatureJSON = JSONObject.Create(creatureJSONString);

            Creature actual = Creature.fromJSONObject(creatureJSON);

            HashSet<Move> expectedMoves = new HashSet<Move>();
            expectedMoves.Add(MoveLibrary.get("Strike"));
            expectedMoves.Add(MoveLibrary.get("Slam"));
            StatModifier sm1 = new StatModifier(5, 1);
            StatModifier sm2 = new StatModifier(0, 1.1);
            StatModifier sm3 = new StatModifier(0, 1);
            FocusPoint fp1 = new FocusPoint(null, null, makeListOfStatMod(StatName.STR, sm1), "Small boost to strength");
            FocusPoint fp2 = new FocusPoint(null, null, makeListOfStatMod(StatName.ARM, sm1), "Small boost to armor");
            FocusPoint fp3 = new FocusPoint(null, null, makeListOfStatMod(StatName.ARM, sm2), "Additional armor scaling");
            FocusPoint fp4 = new FocusPoint(null, null, makeListOfStatMod(StatName.SPD, sm1), "Small boost to speed");
            FocalPoints expectedFocalPoints = new FocalPoints(fp1, fp2, fp3, fp4);
            CreatureStats expectedBaseStats = new CreatureStats(10, 10, 10, 10);
            Ability expectedAbility = null;
            HashSet<CreatureType> expectedTypesBase = new HashSet<CreatureType>();

            expectedTypesBase.Add(CreatureType.VITAL);
            CreatureForm expectedBaseForm = new CreatureForm(expectedTypesBase,null,null);

            HashSet<CreatureType> expectedTypesForm = new HashSet<CreatureType>();
            expectedTypesForm.Add(CreatureType.FLAME);

            List<Pair<StatName, StatModifier>> expectedFormMods = new List<Pair<StatName, StatModifier>>();
            expectedFormMods.Add(new Pair<StatName, StatModifier>(StatName.STR, sm1));
            expectedFormMods.Add(new Pair<StatName, StatModifier>(StatName.ARM, sm3));
            expectedFormMods.Add(new Pair<StatName, StatModifier>(StatName.SPD, sm3));
            CreatureForm expectedAltForm = new CreatureForm(expectedTypesForm, expectedFormMods, null, null, null);

            //"availableForms\":[\n{\n\"creatureTypes\":[\"Flame\"],\n\"statMods\":{\n\"STR\":[5, 1],\n\"ARM\":[0, 1],\n\"SPD\":[0, 1]\n},\n\"moveId\":null,\n\"abilityId\":1,\n\"revealAction\":null\n}\n]

            List<CreatureForm> expectedAvailableForms = new List<CreatureForm>();
            expectedAvailableForms.Add(expectedAltForm);

            foreach(Pair<StatName, StatModifier> pair in expectedAltForm.statMods)
            {
                Debug.Log("Alt form mod: " + pair.ToString());
            }

            Creature expected = new Creature(1, "", expectedMoves, expectedFocalPoints, expectedAbility, expectedBaseStats, expectedBaseForm, expectedAvailableForms);
            
            Assert.That(expected.Equals(actual));
        }

        private List<Pair<StatName, StatModifier>> makeListOfStatMod(StatName statName, StatModifier statMod)
        {
            List<Pair<StatName, StatModifier>> list = new List<Pair<StatName, StatModifier>>();
            list.Add(new Pair<StatName, StatModifier>(statName, statMod));
            return list;
        }
    }
}

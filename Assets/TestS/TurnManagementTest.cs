using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TurnManagementTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void testMovePriorityComparison()
        {
            MovePriority mp1 = new MovePriority(0, 100);
            MovePriority mp2 = new MovePriority(0, 100);
            MovePriority mp3 = new MovePriority(-1, 50);
            MovePriority mp4 = new MovePriority(2, 500);
            MovePriority mp5 = new MovePriority(0, 103);

            //These two are equal in every way
            Assert.That(mp1.Equals(mp2));
            Assert.That(mp1.CompareTo(mp2) == 0);

            //Lower priority values mean that mp3 should go before mp1 regardless of speed
            Assert.That(mp1.Equals(mp3) == false);
            Assert.That(mp3.CompareTo(mp1) < 0);

            //Higher priority values mean that mp4 should go after mp1 regardless of speed
            Assert.That(mp1.Equals(mp4) == false);
            Assert.That(mp4.CompareTo(mp1) > 0);

            //Higher speed when priority is equal means that mp5 goes before mp1
            Assert.That(mp1.Equals(mp5) == false);
            Assert.That(mp5.CompareTo(mp1) < 0);
        }

        [Test]
        public void testTurnManagerGetListOfHighestPrio()
        {
            CreatureStats cs1 = new CreatureStats(1, 1, 1, 10);
            CreatureForm bf1 = new CreatureForm(new HashSet<CreatureType>(new CreatureType[] { CreatureType.VITAL }), null, null);
            Creature c1 = new Creature(0, null, null, null, cs1, bf1, null);
            BattleCreature bc1 = new BattleCreature(c1, Owner.ALLY);

            CreatureStats cs2 = new CreatureStats(1, 1, 1, 20);
            CreatureForm bf2 = new CreatureForm(new HashSet<CreatureType>(new CreatureType[] { CreatureType.VITAL }), null, null);
            Creature c2 = new Creature(0, null, null, null, cs2, bf2, null);
            BattleCreature bc2 = new BattleCreature(c1, Owner.ALLY);

            Move move1 = new Move(0, "TestMove1", "", Move.MoveClass.ATTACK, null, CreatureType.VITAL, 0, 0, 0);
            Move move2 = new Move(0, "TestMove2", "", Move.MoveClass.ATTACK, null, CreatureType.VITAL, 1, 0, 0);
            Move move3 = new Move(0, "TestMove2", "", Move.MoveClass.ATTACK, null, CreatureType.VITAL, -3, 0, 0);



        }
    }
}

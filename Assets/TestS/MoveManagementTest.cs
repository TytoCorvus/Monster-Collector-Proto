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
        public void testMoveManagerGetListOfHighestPrio()
        {
            Watchers testWatchers = new Watchers();

            CreatureStats cs1 = new CreatureStats(1, 1, 1, 10);
            CreatureForm bf1 = new CreatureForm(new HashSet<CreatureType>(new CreatureType[] { CreatureType.VITAL }), null, null);
            FocusPoint f1 = new FocusPoint(null, null, null, null);
            FocalPoints fp1 = new FocalPoints(f1, f1, f1, f1);
            Creature c1 = new Creature(0, "", null, fp1, null, cs1, bf1, null);
            BattleCreature bc1 = new BattleCreature(c1, Owner.ALLY, testWatchers);

            CreatureStats cs2 = new CreatureStats(1, 1, 1, 20);
            CreatureForm bf2 = new CreatureForm(new HashSet<CreatureType>(new CreatureType[] { CreatureType.VITAL }), null, null);
            FocusPoint f2 = new FocusPoint(null, null, null, null);
            FocalPoints fp2 = new FocalPoints(f2, f2, f2, f2);
            Creature c2 = new Creature(0, "", null, fp2, null, cs2, bf2, null);
            BattleCreature bc2 = new BattleCreature(c2, Owner.ALLY, testWatchers);

            Move move1 = new Move(0, "TestMove1", "", Move.MoveClass.ATTACK, TargetClass.ENEMY_SINGLE, null, CreatureType.VITAL, 0, 0, 0);
            Move move2 = new Move(1, "TestMove2", "", Move.MoveClass.ATTACK, TargetClass.ENEMY_SINGLE, null, CreatureType.VITAL, 1, 0, 0);
            Move move3 = new Move(2, "TestMove3", "", Move.MoveClass.ATTACK, TargetClass.ENEMY_SINGLE, null, CreatureType.VITAL, -3, 0, 0);

            MoveContext context1 = new MoveContext(move1, bc1, null, null, null);
            MoveContext context2 = new MoveContext(move2, bc2, null, null, null);
            MoveContext context3 = new MoveContext(move3, bc1, null, null, null);
            MoveContext context4 = new MoveContext(move1, bc2, null, null, null);

            //bc2 moves faster than bc1
            //Order of prio: move3, move1, move2
            //Resulting move order should then be: context3, context4, context1, context2
            HashSet<MoveContext> contexts = new HashSet<MoveContext>(new MoveContext[] {context1, context2, context3, context4});
            MoveManager moveManager = new MoveManager(null, null, contexts);

            MoveContext actual1 = moveManager.getNextMove();
            MoveContext actual2 = moveManager.getNextMove();

            Assert.That(moveManager.getMovesRemaining() == 2);
            Assert.That(moveManager.isTurnOver() == false);

            MoveContext actual3 = moveManager.getNextMove();
            MoveContext actual4 = moveManager.getNextMove();

            Assert.That(moveManager.getMovesRemaining() == 0);
            Assert.That(moveManager.isTurnOver());

            Assert.That(actual1.Equals(context3));
            Assert.That(actual2.Equals(context4));
            Assert.That(actual3.Equals(context1));
            Assert.That(actual4.Equals(context2));
        }
    }
}

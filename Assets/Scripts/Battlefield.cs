using System.Collections.Generic;
using UnityEngine;
public class Battlefield : MonoBehaviour
{
    public int playerSize = 1;
    public int enemySize = 1;
    public BattleUIManager battleUIManager;

    private Watchers watchers;
    private BattlefieldPositionManager positionManager;

    public List<BattleCreature> playerCreatures;
    private List<BattleCreature> enemyCreatures;

    public void Start()
    {
        this.watchers = new Watchers();
    }

    public List<Pair<BattleCreature, Move>> getMoveRequests()
    {
        //TODO make more intelligent move requesting for enemies
        List<Pair<BattleCreature, Move>> moveRequests = new List<Pair<BattleCreature, Move>>();
        foreach (BattleCreature bc in enemyCreatures)
        {
            //TODO fix move selection
            //moveRequests.Add(new Pair<BattleCreature, Move>(bc, selectRandomMove(bc)));
        }

        moveRequests.AddRange(getPlayerCreatureMoveRequests());

        return moveRequests;
    }

    private List<Pair<BattleCreature, Move>> getPlayerCreatureMoveRequests()
    {
        //TODO properly implement
        List<Pair<BattleCreature, Move>> moveReqs = new List<Pair<BattleCreature, Move>>();

        return moveReqs;
    }

    public List<BattleCreature> getTurnOrder()
    {
        //TODO Make this work as intended, based off of speed
        List<BattleCreature> order = new List<BattleCreature>();
        order.AddRange(playerCreatures);
        order.AddRange(enemyCreatures);
        return order;
    }

    private List<BattleActionContext> getActionContexts(Move move, BattleCreature source)
    {
        List<BattleActionContext> result = new List<BattleActionContext>();

        List<BattleCreature> otherCreatures = source.owner == Owner.PLAYER || source.owner == Owner.ALLY ? enemyCreatures : playerCreatures;
        List<BattleCreature> friendlyCreatures = source.owner == Owner.PLAYER_ENEMY || source.owner == Owner.COMPUTER ? playerCreatures : enemyCreatures;

        foreach (BattleAction ba in move.battleActions)
        {

            List<BattleCreature> targets = new List<BattleCreature>();

            switch (ba.targetClass)
            {
                case TargetClass.SELF:
                    targets.Add(source);
                    break;
                case TargetClass.ENEMY_ALL:
                    targets.AddRange(otherCreatures);
                    break;
                case TargetClass.ENEMY_SINGLE:
                    //TODO allow the game to prompt the player for which enemy
                    targets.Add(otherCreatures[0]);
                    break;
                case TargetClass.ALLY:
                    //TODO allow the game to prmpt the player for which ally
                    targets.Add(friendlyCreatures[0]);
                    break;
                case TargetClass.ALLY_ALL:
                    targets.AddRange(friendlyCreatures);
                    break;
                case TargetClass.ALL:
                    targets.AddRange(otherCreatures);
                    targets.AddRange(friendlyCreatures);
                    break;
            }

            result.Add(buildContextForCreature(ba, source, targets));
        }

        return result;
    }

    private BattleActionContext buildContextForCreature(BattleAction action, BattleCreature source, List<BattleCreature> targets)
    {
        //TODO alter the specific context for things like focus or creature buffs
        return new BattleActionContext(action, source, targets, 1, 1);
    }

    public bool isBattleOver()
    {
        bool enemyWhiteOut = true;
        bool allyWhiteOut = true;

        foreach(BattleCreature bc in enemyCreatures)
        {
            enemyWhiteOut &= bc.isKnockedOut();
        }

        foreach (BattleCreature bc in playerCreatures)
        {
            allyWhiteOut &= bc.isKnockedOut();
        }

        return enemyWhiteOut || allyWhiteOut;
    }
}

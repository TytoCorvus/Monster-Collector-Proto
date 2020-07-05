using System.Collections.Generic;
using UnityEngine;
public class BattleManager
{
    public int playerSize = 1;
    public int enemySize = 1;

     public BattleUIManager battleUIManager;
    private Watchers watchers;
    private BattlefieldPositionManager positionManager;

    public BattleManager(BattleUIManager battleUIManager, Pair<int, int> battlefieldSize, BattleCreature[] team1, BattleCreature[] team2)
    {
        this.watchers = new Watchers();
        this.positionManager = new BattlefieldPositionManager(battlefieldSize.getFirst(), battlefieldSize.getSecond());
    }

    private List<Pair<BattleCreature, Move>> getPlayerCreatureMoveRequests()
    {
        //TODO properly implement
        List<Pair<BattleCreature, Move>> moveReqs = new List<Pair<BattleCreature, Move>>();

        return moveReqs;
    }
}

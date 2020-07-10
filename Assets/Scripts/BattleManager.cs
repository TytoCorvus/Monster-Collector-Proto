using System.Collections.Generic;
using UnityEngine;
public class BattleManager
{
    public BattleUIManager battleUIManager;
    private Watchers watchers;
    private BattlefieldPositionManager positionManager;
    private BattleActionResolver actionResolver;
    private TurnManager turnManager;
    private BattleTeam team1;
    private BattleTeam team2;

    public BattleManager(BattleUIManager battleUIManager, Pair<int, int> battlefieldSize, Team team1, Team team2)
    {
        this.battleUIManager = battleUIManager;
        this.watchers = new Watchers();
        this.actionResolver = new BattleActionResolver(watchers.battleActionWatcher, battleUIManager);
        this.turnManager = new TurnManager(actionResolver, watchers.turnPhaseWatcher);
        this.positionManager = new BattlefieldPositionManager(battlefieldSize.getFirst(), battlefieldSize.getSecond());
        this.team1 = new BattleTeam(team1, Owner.PLAYER, watchers);
        this.team2 = new BattleTeam(team2, Owner.COMPUTER, watchers);
    }

    private List<Pair<BattleCreature, Move>> getPlayerCreatureMoveRequests()
    {
        //TODO properly implement
        List<Pair<BattleCreature, Move>> moveReqs = new List<Pair<BattleCreature, Move>>();

        return moveReqs;
    }
}

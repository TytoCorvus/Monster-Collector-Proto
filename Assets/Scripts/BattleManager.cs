using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleManager : MonoBehaviour
{
    public BattleUIManager battleUIManager;
    private Watchers watchers;
    private BattlefieldPositionManager positionManager;
    private BattleActionResolver actionResolver;
    private BattleTeam team1;
    private BattleTeam team2;

    private static List<TurnPhase> turnPhases = new List<TurnPhase>(new TurnPhase[] {TurnPhase.ACTION_SELECT, TurnPhase.BEGIN, TurnPhase.EARLY_SWITCH, TurnPhase.MOVE_RESOLUTION, TurnPhase.LATE_SWITCH, TurnPhase.END});
    private int currentTurnPhase;

    public void Start()
    {
        LibraryLoader.loadMoveLibrary();
        List<Creature> creatures1 = LibraryLoader.loadTestCreatures();
        List<Creature> creatures2 = LibraryLoader.loadTestCreatures();

        setup( new Pair<int, int>(1, 1), new Team(creatures1), new Team(creatures2));
        StartCoroutine(begin());
    }

    public void setup(Pair<int, int> battlefieldSize, Team team1, Team team2)
    {
        this.battleUIManager = battleUIManager;
        this.positionManager = new BattlefieldPositionManager(battlefieldSize.getFirst(), battlefieldSize.getSecond());
        this.battleUIManager.setup(positionManager);
        this.battleUIManager.setShowCreatureUi(true);

        this.watchers = new Watchers();
        this.actionResolver = new BattleActionResolver(watchers.battleActionWatcher, battleUIManager);
        this.team1 = new BattleTeam(team1, Owner.PLAYER, watchers);
        this.team2 = new BattleTeam(team2, Owner.COMPUTER, watchers);
        this.currentTurnPhase = 0;

        beginBattleLoop();
    }

    private async List<Pair<BattleCreature, Move>> getPlayerCreatureMoveRequests()
    {
        //TODO properly implement
        List<Pair<BattleCreature, Move>> moveReqs = new List<Pair<BattleCreature, Move>>();

        return moveReqs;
    }

    private async void beginBattleLoop()
    {
        while (!isBattleOver())
        {
            TurnPhase nextTurnPhase = turnPhases[currentTurnPhase];

            switch (nextTurnPhase)
            {
                case TurnPhase.ACTION_SELECT:
                    battleUIManager.addMessage("Select Actions", true);
                    List<MoveContext> moveSelection = await getPlayerCreatureMoveRequests();
                    //yield return battleUIManager.getMoveSelection(positionManager.getOccupant(new BattlefieldPosition(), (MoveContext context) => { });
                    break;
                case TurnPhase.EARLY_SWITCH:
                    battleUIManager.addMessage(nextTurnPhase.ToString(), true);
                    break;
                case TurnPhase.MOVE_RESOLUTION:
                    battleUIManager.addMessage("Resolve Moves", true);
                    break;
                case TurnPhase.LATE_SWITCH:
                    battleUIManager.addMessage(nextTurnPhase.ToString(), true);
                    break;
                default:
                    battleUIManager.addMessage(nextTurnPhase.ToString(), true);
                    break;
            }

            battleUIManager.updateAllUI();

            yield return battleUIManager.waitUntilUpdatesComplete();

            currentTurnPhase++;
            if (currentTurnPhase >= turnPhases.Count)
                currentTurnPhase = 0;
        }


        yield return null;

        endBattle();
    }

    private bool isBattleOver()
    {
        return team1.isTeamFainted() || team2.isTeamFainted();
    }

    private void endBattle()
    {

    }
}

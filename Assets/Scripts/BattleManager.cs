using System;
using System.Threading.Tasks;
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

        setup( new Pair<int, int>(1, 0), new Team(creatures1), new Team(creatures2));
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

        BattleCreature testCreature1 = new BattleCreature(team1.getCreatures()[0], Owner.PLAYER, watchers);
        BattleCreature testCreature2 = new BattleCreature(team2.getCreatures()[0], Owner.COMPUTER, watchers);

        this.positionManager.place(testCreature1, new BattlefieldPosition(1,BattlefieldPosition.PositionType.PRIMARY, 0));

        this.currentTurnPhase = 0;

        beginBattleLoop();
    }

    private async Task<List<MoveContext>> getPlayerCreatureMoveRequests()
    {
        //TODO properly implement
        //List<Pair<BattleCreature, Move>> moveReqs = new List<Pair<BattleCreature, Move>>();

        List<BattleCreature> activeCreatures = positionManager.getActiveCreatures();
        BattleCreature c = positionManager.getActiveCreatures()[0];
        List<SelectButton<Move>> buttons = new List<SelectButton<Move>>();
        c.getMoves().ForEach(m =>
            {
            buttons.Add( SelectButton<Move>.create(m) );
            });

        List<SelectButton<Move>> dblButtons = new List<SelectButton<Move>>();
        dblButtons.AddRange(buttons);
        dblButtons.AddRange(buttons);

        Move move = await battleUIManager.getSelection<Move>(dblButtons, c.creature.creatureName + " move selection:");
        List<BattleCreature> targets = new List<BattleCreature>();

        switch (move.targetClass)
        {
            case TargetClass.ENEMY_SINGLE:
                break;
            case TargetClass.ALLY_SINGLE:
                break;
            case TargetClass.ALLY_ALL:
                break;
            case TargetClass.ENEMY_ALL:
                break;
            case TargetClass.ALL:
                break;

        }

        Debug.Log("Move selected: " + move.ToString());


        MoveContext context = new MoveContext(move, c, null, null, null);

        return new List<MoveContext> { context };
    }

    

    private async void beginBattleLoop()
    {
        while (!isBattleOver())
        {

            List<MoveContext> moveSelection = await getPlayerCreatureMoveRequests();

            await Task.Delay(4000);
        }

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

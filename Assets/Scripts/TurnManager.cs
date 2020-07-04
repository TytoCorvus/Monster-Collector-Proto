using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager 
{
    private System.Random rand;
    private BattleActionResolver resolver;
    private TurnPhaseWatcher phaseWatcher;


    private HashSet<MoveContext> remainingMoveRequests;

    public TurnManager(BattleActionResolver resolver, TurnPhaseWatcher phaseWatcher)
    {
        this.rand = new System.Random();
        this.remainingMoveRequests = new HashSet<MoveContext>();
        this.resolver = resolver;
        this.phaseWatcher = phaseWatcher;
    }

    public void beginTurn(HashSet<MoveContext> moveRequests)
    {
        resolveTurnPhase(TurnPhase.BEGIN);


        if (!isTurnOver())
        {
            throw new System.Exception("The turn is not over - we cannot begin a new turn yet");
        }
        this.remainingMoveRequests = moveRequests;

        resolveTurnPhase(TurnPhase.END);
    }

    private void resolveTurnPhase(TurnPhase phase)
    {
        List<BattleActionContext> responses = phaseWatcher.getResponses(phase).Where(bac => bac != null).ToList();
        foreach (BattleActionContext ba in responses)
            resolver.resolveAction(ba);
    }

    public bool isTurnOver()
    {
        return remainingMoveRequests.Count == 0;
    }

    public int getMovesRemaining()
    {
        return remainingMoveRequests.Count;
    }

    public MoveContext getNextMove()
    {
        List<MoveContext> highestPrioMoves = getHighestPriorityMoves();
        MoveContext chosenMove = null;
        if (highestPrioMoves.Count == 1)
            chosenMove = highestPrioMoves[0];
        else if(highestPrioMoves.Count > 1)
            chosenMove = breakSpeedTie(highestPrioMoves);

        remainingMoveRequests.Remove(chosenMove);
        return chosenMove;
    }

    public List<MoveContext> getHighestPriorityMoves()
    {
        MovePriority highestPrio = null;
        List<MoveContext> highestPrioList = new List<MoveContext>();

        foreach(MoveContext mc in remainingMoveRequests)
        {
            if(highestPrio == null)
            {
                highestPrio = mc.getMovePriority();
                highestPrioList.Add(mc);
            }
            else
            {
                if (mc.getMovePriority().Equals(highestPrio))
                {
                    highestPrioList.Add(mc);
                } 
                else if(mc.getMovePriority().CompareTo(highestPrio) < 0)
                {
                    highestPrio = mc.getMovePriority();
                    highestPrioList.Clear();
                    highestPrioList.Add(mc);
                }
            }
        }

        return highestPrioList;
    }

    public MoveContext breakSpeedTie(List<MoveContext> tied)
    {
        
        return tied[rand.Next(0, tied.Count - 1)];
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveManager 
{
    private System.Random rand;
    private BattleActionResolver resolver;
    private TurnPhaseWatcher phaseWatcher;


    private HashSet<MoveContext> remainingMoveRequests;

    public MoveManager(BattleActionResolver resolver, TurnPhaseWatcher phaseWatcher, HashSet<MoveContext> moveContexts)
    {
        this.rand = new System.Random();
        this.remainingMoveRequests = new HashSet<MoveContext>();
        this.resolver = resolver;
        this.phaseWatcher = phaseWatcher;
        this.remainingMoveRequests = moveContexts;
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

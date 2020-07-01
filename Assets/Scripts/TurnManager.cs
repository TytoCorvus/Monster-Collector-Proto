using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager 
{

    //private Queue<> moveQueue;
    //private Queue<> battleActionQueue;
    private BattleActionResolver resolver;

    private bool turnIsOver = true;
    private List<MoveContext> remainingMoveRequests;

    public TurnManager(BattleActionResolver resolver)
    {
        this.resolver = resolver;
    }

    public void beginTurn(List<MoveContext> moveRequests)
    {
        this.turnIsOver = false;
        this.remainingMoveRequests = moveRequests;
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public readonly MoveClass moveClass;
    public readonly List<BattleAction> moveActions;

    public Move(MoveClass moveClass, List<BattleAction> moveActions)
    {
        this.moveClass = moveClass;
        this.moveActions = moveActions;
    }

    public bool canExecute()
    {

    }

    public void execute()
    {

    }

    public enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }
}

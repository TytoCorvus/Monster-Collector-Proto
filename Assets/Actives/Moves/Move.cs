using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public readonly MoveClass moveClass;
    public readonly TargetClass targetClass;

    public readonly List<BattleAction> moveActions;

    public Move(MoveClass moveClass, TargetClass targetClass, List<BattleAction> moveActions)
    {
        this.moveClass = moveClass;
        this.targetClass = targetClass;
        this.moveActions = moveActions;
    }

    public void execute(Target target)
    {

    }

    public enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }
}

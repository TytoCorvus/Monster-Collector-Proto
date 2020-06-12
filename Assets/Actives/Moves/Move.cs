using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public readonly MoveClass moveClass;
    public readonly List<BattleAction> moveActions;

    private readonly int focusCost;
    private readonly int healthCost;

    public Move(MoveClass moveClass, List<BattleAction> moveActions, int focusCost, int healthCost)
    {
        this.moveClass = moveClass;
        this.moveActions = moveActions;
        this.focusCost = focusCost;
        this.healthCost = healthCost;
    }

    public bool canExecute(BattleActionContext context)
    {
        BattleCreature source = context.source;
        //TODO Update logic to require targets from all reqired BattleActions based on the context or list of contexts
        return !(source.isKnockedOut()) && source.focus.getCurrentFocus() >= focusCost && source.currentHP >= healthCost;
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

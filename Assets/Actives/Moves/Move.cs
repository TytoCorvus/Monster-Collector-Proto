using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{
    public readonly MoveClass moveClass;
    public readonly List<BattleAction> moveActions;

    private readonly int focusChange;
    private readonly int healthChange;

    public Move(MoveClass moveClass, List<BattleAction> moveActions, int focusChange, int healthChange)
    {
        this.moveClass = moveClass;
        this.moveActions = moveActions;
        this.focusChange = focusChange;
        this.healthChange = healthChange;
    }

    public bool canExecute(BattleActionContext context)
    {
        BattleCreature source = context.source;
        //TODO Update logic to require targets from all reqired BattleActions based on the context or list of contexts
        return !(source.isKnockedOut()) && source.focus.getCurrentFocus() >= focusChange && source.currentHP >= healthChange;
    }

    public void applyCosts(BattleCreature source)
    {
        source.changeHealth(healthChange);
        source.focus.alterCurrentFocus(focusChange);
    }

    public enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }
}

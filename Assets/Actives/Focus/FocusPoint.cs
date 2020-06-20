using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FocusPoint
{
    private readonly FocusTrigger focusTrigger;
    private readonly BattleAction battleAction;
    private readonly List<Pair<StatName, StatModifier>> statModifiers;
    private readonly string description;
    public FocusPoint(FocusTrigger focusTrigger, BattleAction battleAction, List<Pair<StatName, StatModifier>> statModifiers, string description)
    {
        this.focusTrigger = focusTrigger;
        this.battleAction = battleAction;
        this.statModifiers = statModifiers;
        this.description = description;
    }

    public bool hasActive()
    {
        return focusTrigger != null && battleAction != null;
    }

    public bool hasStatModifier()
    {
        return statModifiers != null && statModifiers.Count != 0;
    }

    public List<Pair<StatName, StatModifier>> getStatModifiers()
    {
        return statModifiers;
    }

    public override string ToString()
    {
        return description;
    }
}

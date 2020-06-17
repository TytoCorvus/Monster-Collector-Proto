using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint
{
    private bool active;
    private BattleAction apply;
    private BattleAction remove;

    public FocusPoint(BattleAction apply, BattleAction remove)
    {
        this.apply = apply;
        this.remove = remove;
    }

    public void apply(double multiplier)
    {
        active = true;

    }

    public void remove(double multiplier)
    {
        active = false;

    }
}

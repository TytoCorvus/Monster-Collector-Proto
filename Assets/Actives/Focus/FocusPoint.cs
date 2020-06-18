using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPoint
{
    private bool active;
    private readonly double multiplier;
    private readonly FocusPointType trigger;
    private readonly string description;
    public FocusPoint(FocusPointType trigger)
    {
        this.trigger = trigger;
        this.battleAction = battleAction;
    }


    public virtual bool isStatMod()
    {

    }

    public virtual bool isTrigger()
    {

    }

    public virtual void apply(double multiplier)
    {
        active = true;
        multiplier = multiplier;
    }

    public virtual void remove()
    {
        active = false;

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction
{
    private readonly TargetClass targetClass;

    public BattleAction(TargetClass targetClass)
    {
        this.targetClass = targetClass;
    }

    public virtual void execute(BattleActionSource source, List<Target> targets)
    {

    }

}

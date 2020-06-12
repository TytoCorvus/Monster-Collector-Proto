using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionsSharingContext : BattleAction
{
    private List<BattleAction> battleActions;
    public BattleActionsSharingContext(TargetClass targetClass, List<BattleAction> battleActions) : base(targetClass)
    {
        this.battleActions = battleActions;
    }

    public override void execute(BattleActionContext battleActionContext)
    {
        foreach (BattleAction ba in battleActions)
        {
            ba.execute(battleActionContext);
        }
    }

    public override bool canExecute(BattleActionContext battleActionContext)
    {
        bool canExecute = true;
        foreach (BattleAction ba in battleActions)
        {
            canExecute = canExecute && ba.canExecute(battleActionContext);
        }
        return canExecute;
    }
}

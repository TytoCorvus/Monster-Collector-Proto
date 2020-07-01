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

    public override BattleActionResult execute(BattleActionContext battleActionContext)
    {
        //TODO fix return statement(If composite battle actions are even required)
        foreach (BattleAction ba in battleActions)
        {
            if (ba.execute(battleActionContext) != null) { return null; }
        }
        return null;
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

    public static BattleAction fromJSONObject(JSONObject json)
    {
        //TODO properly implement
        return null;
    }
}

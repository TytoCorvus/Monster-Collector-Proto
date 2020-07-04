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

    public override BattleActionResult execute(BattleCreature source, List<BattleCreature> targets, double amp, double hitChanceMultiplier, double alteredChanceForSecondary)
    {
        foreach (BattleAction ba in battleActions)
        {
            if (ba.execute(source, targets, amp, hitChanceMultiplier, alteredChanceForSecondary) != null) { return null; }
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

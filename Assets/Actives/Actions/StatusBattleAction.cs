using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattleAction : BattleAction
{
    private readonly StatusType statusType;
    private readonly int statusValue;
    private readonly CreatureType creatureType;
    private readonly double chanceToHit;

    public StatusBattleAction(TargetClass targetClass, StatusType statusType, int statusValue, CreatureType creatureType, double chanceToHit) : base(targetClass)
    {
        this.statusType = statusType;
        this.statusValue = statusValue;
        this.creatureType = creatureType;
        this.chanceToHit = chanceToHit;
    }

    public override BattleActionResult execute(BattleActionContext actionContext)
    {
        //TODO properly implement status conditions
        return null;
    }

    public static BattleAction fromJSONObject(JSONObject json)
    {
        return null;
    }

    //TODO create status application details
    public enum StatusType
    {
        TOXIN,
        STUN,
        CHILL,
        FEAR
    }
}

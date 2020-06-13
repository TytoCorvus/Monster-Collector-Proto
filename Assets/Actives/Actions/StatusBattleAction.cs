using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBattleAction : BattleAction
{

    public StatusBattleAction(TargetClass targetClass, StatusType statusType, int statusValue, CreatureType creatureType, double chanceToHit) : base(targetClass)
    {
        this.basePower = basePower;
        this.damageType = damageType;
        this.chanceToHit = chanceToHit;
    }

    public override int execute(BattleActionContext actionContext)
    {
        //TODO properly implement status conditions
        return 0;
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

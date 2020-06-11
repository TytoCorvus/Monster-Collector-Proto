using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BattleAction
{
    private readonly int basePower;
    private readonly CreatureType damageType;
    private readonly Creature source;

    public Damage(TargetClass targetClass, int basePower, CreatureType damageType)
    {
        base(targetClass);
        this.basePower = basePower;
        this.damageType = damageType;
        this.source = source;
    }

    public override void execute(BattleActionSource source, List<Target> targets)
    {

    }


}

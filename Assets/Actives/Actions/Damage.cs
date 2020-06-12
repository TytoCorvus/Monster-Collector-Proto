using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BattleAction
{

    private readonly int basePower;
    private readonly CreatureType damageType;

    public Damage(TargetClass targetClass, int basePower, CreatureType damageType) : base(targetClass)
    {
        this.basePower = basePower;
        this.damageType = damageType;
    }

    public override void execute(BattleActionContext actionContext)
    {
        foreach (BattleCreature target in actionContext.targets)
        {
            double typeMultiplier = damageType.getDamageMultiplierVs(target.creature.creatureTypes);

            target.changeHealth(DamageUtils.calculateDamage(basePower * typeMultiplier,
                                                            actionContext.source.creature.getStats(),
                                                            target.creature.getStats()));
        }
    }
}

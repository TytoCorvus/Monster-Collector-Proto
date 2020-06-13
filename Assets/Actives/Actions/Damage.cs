using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : BattleAction
{

    private readonly int basePower;
    private readonly CreatureType damageType;
    private readonly double chanceToHit;

    public Damage(TargetClass targetClass, int basePower, CreatureType damageType, double chanceToHit) : base(targetClass)
    {
        this.basePower = basePower;
        this.damageType = damageType;
        this.chanceToHit = chanceToHit;
    }

    public override int execute(BattleActionContext actionContext)
    {
        bool targetsHit = false;
        foreach (BattleCreature target in actionContext.targets)
        {
            if (!target.isKnockedOut())
            {
                if (RandomUtils.checkOdds(chanceToHit * (1 + actionContext.alteredChanceToHit)))
                {
                    double typeMultiplier = damageType.getDamageMultiplierVs(target.creature.creatureTypes);

                    target.changeHealth(DamageUtils.calculateDamage(basePower * typeMultiplier,
                                                                    actionContext.source.creature.getStats(),
                                                                    target.creature.getStats()));
                    targetsHit = true;
                }
            }
        }
        return targetsHit ? 0 : 1;
    }
}

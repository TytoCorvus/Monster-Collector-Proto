using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionContext
{
    public readonly BattleCreature source;
    public readonly List<BattleCreature> targets;
    public readonly double damageAmp;
    public readonly bool sameTypeBonus;
    public BattleActionContext(BattleCreature source, List<BattleCreature> targets, double damageAmp, bool sameTypeBonus)
    {
        this.source = source;
        this.targets = targets;
        this.damageAmp = damageAmp;
        this.sameTypeBonus = sameTypeBonus;
    }

    public bool hasTargets()
    {
        return targets.Count > 0;
    }
}

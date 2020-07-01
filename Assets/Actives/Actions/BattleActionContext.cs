using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionContext
{
    public BattleCreature source;
    public List<BattleCreature> targets;
    public readonly BattleAction action;
    public double damageAmp;
    public bool sameTypeBonus;
    public double alteredChanceToHit;
    public double alteredChanceForSecondary;
    public BattleActionContext(BattleCreature source, List<BattleCreature> targets, double damageAmp, bool sameTypeBonus,
                                double alteredChanceToHit, double alteredChanceForSecondary)
    {
        this.source = source;
        this.targets = targets;
        this.damageAmp = damageAmp;
        this.sameTypeBonus = sameTypeBonus;
        this.alteredChanceToHit = alteredChanceToHit;
        this.alteredChanceForSecondary = alteredChanceForSecondary;
    }

    public bool hasTargets()
    {
        return targets.Count > 0;
    }
}

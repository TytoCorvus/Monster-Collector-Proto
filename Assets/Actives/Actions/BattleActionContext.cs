using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionContext
{
    public readonly BattleAction action;
    public BattleCreature source;
    public List<BattleCreature> targets;
    public double amp;
    public double hitChanceMultiplier;
    public double alteredChanceForSecondary;
    public BattleActionContext(BattleAction action, BattleCreature source, List<BattleCreature> targets, double amp,
                                double hitChanceMultiplier)
    {
        this.action = action;
        this.source = source;
        this.targets = targets;
        this.amp = amp;
        this.hitChanceMultiplier = hitChanceMultiplier;
    }

    public bool canExecute()
    {
        return hasTargets();
    }

    public bool hasTargets()
    {
        return targets.Count > 0;
    }

    public virtual BattleActionResult execute()
    {
        return null;
    }
}

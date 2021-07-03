using System.Collections;
using System.Collections.Generic;

public class BattleAction
{
    public readonly TargetClass targetClass;
    public readonly string message;

    public BattleAction(TargetClass targetClass)
    {
        this.targetClass = targetClass;
        this.message = null;
    }

    public BattleAction(TargetClass targetClass, string message)
    {
        this.targetClass = targetClass;
        this.message = message;
    }

    public virtual BattleActionResult execute(BattleCreature source, List<BattleCreature> targets, double amp, double hitChanceMultiplier, double alteredChanceForSecondary)
    {
        return BattleActionResult.NO_CHANGES;
    }

    public virtual bool canExecute(BattleActionContext actionContext)
    {
        return actionContext.source != null && !actionContext.source.isKnockedOut();
    }

    public virtual bool hasMessage()
    {
        return message == null ? false : true;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
}

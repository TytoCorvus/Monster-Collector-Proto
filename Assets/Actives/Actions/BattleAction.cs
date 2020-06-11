using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAction
{
    private readonly TargetClass targetClass;
    private readonly string message;

    public BattleAction(TargetClass targetClass, string message)
    {
        this.targetClass = targetClass;
        this.message = message;
    }

    public virtual void execute(BattleActionContext actionContext) { }

    public virtual bool canExecute(BattleActionContext actionContext)
    {
        return true;
    }

    public virtual bool hasMessage()
    {
        return message == null ? false : true;
    }

}

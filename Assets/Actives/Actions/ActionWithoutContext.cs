using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ActionWithoutContext
{
    public readonly BattleAction action;
    public readonly TargetClass targetClass;

    public ActionWithoutContext(BattleAction action, TargetClass targetClass)
    {
        this.action = action;

        if(targetClass == TargetClass.ENEMY_SINGLE || targetClass == TargetClass.ALLY_SINGLE)
        {
            throw new Exception("Cannot instantiate action without context for Target Class ENEMY_SINGLE or ALLY");
        }

        this.targetClass = targetClass;
    }
}

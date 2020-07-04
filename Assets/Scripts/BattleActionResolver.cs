using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionResolver
{
    private readonly BattleActionWatcher watcher;

    public BattleActionResolver(BattleActionWatcher watcher)
    {
        this.watcher = watcher;
    }

    public BattleActionResult resolveAction(BattleActionContext battleActionContext, MoveContext moveContext)
    {
        BattleActionContext alteredAction = watcher.getAlteredBattleAction(battleActionContext, moveContext);
        BattleActionResult result = null;
        if (alteredAction.canExecute())
            result = battleActionContext.execute();

        return result;
    }

    public BattleActionResult resolveAction(BattleActionContext battleActionContext)
    {
        BattleActionContext alteredAction = watcher.getAlteredBattleAction(battleActionContext);
        BattleActionResult result = null;
        if (alteredAction.canExecute())
            result = battleActionContext.execute();

        return result;
    }
}

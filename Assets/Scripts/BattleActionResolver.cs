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

    public BattleActionResult resolveAction(BattleAction battleAction, MoveContext moveContext, BattleActionContext battleActionContext)
    {
        Pair<BattleAction, BattleActionContext> alteredAction = watcher.getAlteredBattleAction(battleAction, battleActionContext, moveContext);
        BattleActionResult result = null;
        if (alteredAction.getFirst() != null && alteredAction.getFirst().canExecute(battleActionContext))
            result = alteredAction.getFirst().execute(battleActionContext);

        return result;
    }
}

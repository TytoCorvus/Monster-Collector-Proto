using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watchers
{
    public readonly TurnPhaseWatcher turnPhaseWatcher;
    public readonly BattleActionWatcher battleActionWatcher;

    public Watchers()
    {
        this.turnPhaseWatcher = new TurnPhaseWatcher();
        this.battleActionWatcher = new BattleActionWatcher();
    }
}

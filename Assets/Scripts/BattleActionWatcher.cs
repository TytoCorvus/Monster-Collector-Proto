using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class BattleActionWatcher
{
    private readonly List<IBattleActionListener> damageListeners;
    private readonly List<IBattleActionListener> statusListeners;
    private readonly List<IBattleActionListener> switchListeners;

    private List<IBattleActionListener> getListeners(BattleAction action, BattleActionContext battleActionContext, MoveContext moveContext)
    {
        List<IBattleActionListener> listeners = new List<IBattleActionListener>();

        //TODO fix watcher to be more flexible

        List<IBattleActionListener> relevantList = null;
        if (action is DamageBattleAction)
            relevantList = damageListeners;
        if (action is StatusBattleAction)
            relevantList = statusListeners;

        if(relevantList != null)
        {
            foreach(IBattleActionListener listener in relevantList)
            {
                if (listener.isListeningFor(action))
                    listeners.Add(listener);
            }
        }
        return listeners;
    }

    public List<BattleActionContext> buildActionsToResolve(BattleActionContext battleActionContext, MoveContext moveContext)
    {
        //TODO flesh out action watcher
        List<BattleActionContext> actions = new List<BattleActionContext>();
        actions.Add(battleActionContext);

        return actions;
    }

    public BattleActionContext getAlteredBattleAction(BattleActionContext battleActionContext, MoveContext moveContext)
    {
        return battleActionContext;
    }

    public BattleActionContext getAlteredBattleAction(BattleActionContext battleActionContext)
    {
        return battleActionContext;
    }
}


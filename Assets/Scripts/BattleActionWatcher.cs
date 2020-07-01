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

    public List<Pair<BattleAction, BattleActionContext>> buildActionsToResolve(BattleAction action, BattleActionContext battleActionContext, MoveContext moveContext)
    {
        //TODO flesh out action watcher
        List<Pair<BattleAction, BattleActionContext>> actions = new List<Pair<BattleAction, BattleActionContext>>();
        actions.Add(new Pair<BattleAction, BattleActionContext>(action, battleActionContext));

        return actions;
    }

    public Pair<BattleAction, BattleActionContext> getAlteredBattleAction(BattleAction action, BattleActionContext battleActionContext, MoveContext moveContext)
    {
        return new Pair<BattleAction, BattleActionContext>(action, battleActionContext);
    }
}


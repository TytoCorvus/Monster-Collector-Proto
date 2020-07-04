using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class TurnPhaseWatcher
{
    public readonly List<ITurnPhaseListener> endTurnListeners;

    public void listen(ITurnPhaseListener listener, TurnPhase phase)
    {
        switch (phase)
        {
            case TurnPhase.BEGIN:
                break;
            case TurnPhase.ACTION_SELECT:
                break;
            case TurnPhase.EARLY_SWITCH:
                break;
            case TurnPhase.MOVE_RESOLUTION:
                break;
            case TurnPhase.LATE_SWITCH:
                break;
            case TurnPhase.END:
                endTurnListeners.Add(listener);
                break;
            default:
                break;
        }
    }

    public void deafen(ITurnPhaseListener listener, TurnPhase phase)
    {
        switch (phase)
        {
            case TurnPhase.BEGIN:
                break;
            case TurnPhase.ACTION_SELECT:
                break;
            case TurnPhase.EARLY_SWITCH:
                break;
            case TurnPhase.MOVE_RESOLUTION:
                break;
            case TurnPhase.LATE_SWITCH:
                break;
            case TurnPhase.END:
                endTurnListeners.Remove(listener);
                break;
            default:
                break;
        }
    }

    public List<BattleActionContext> getResponses(TurnPhase phase)
    {
        List<BattleActionContext> actions = new List<BattleActionContext>();
        foreach (ITurnPhaseListener tpl in getPhaseListeners(phase))
            actions.Add(tpl.respond(phase));

        return actions;
    }

    public List<ITurnPhaseListener> getPhaseListeners(TurnPhase phase)
    {
        List<ITurnPhaseListener> interested = null;

        switch (phase)
        {
            case TurnPhase.BEGIN:
                break;
            case TurnPhase.ACTION_SELECT:
                break;
            case TurnPhase.EARLY_SWITCH:
                break;
            case TurnPhase.MOVE_RESOLUTION:
                break;
            case TurnPhase.LATE_SWITCH:
                break;
            case TurnPhase.END:
                interested = endTurnListeners;
                break;
            default:
                break;
        }

        if (interested == null)
            return new List<ITurnPhaseListener>();
        else
            return interested;
    }
}


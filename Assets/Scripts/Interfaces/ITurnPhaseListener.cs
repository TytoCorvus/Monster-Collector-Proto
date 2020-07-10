using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITurnPhaseListener
{
    void subscribe(TurnPhaseWatcher watcher);
    void unsubscribe();
    bool isListeningFor(TurnPhase phase);
    BattleActionContext respond(TurnPhase phase);
}


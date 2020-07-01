using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface IBattleActionListener
{
    bool isListeningFor(BattleAction battleAction);
}

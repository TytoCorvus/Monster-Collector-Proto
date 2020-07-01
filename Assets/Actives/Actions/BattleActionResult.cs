using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BattleActionResult
{
    public readonly bool succeeded;
    public readonly bool hadTargets;

    public BattleActionResult(bool succeeded, bool hadTargets)
    {
        this.succeeded = succeeded;
        this.hadTargets = hadTargets;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DamageBattleActionResult : BattleActionResult
{
    int damageDealt;
    CreatureType damageType;
    BattleCreature source;
    List<BattleCreature> targets;
    List<BattleCreature> targetsHit;

    public DamageBattleActionResult(bool succeeded, bool hadTargets, int damageDealt, CreatureType damageType, BattleCreature source, List<BattleCreature> targets, List<BattleCreature> targetsHit) : base(succeeded, hadTargets)
    {
        this.damageDealt = damageDealt;
        this.damageType = damageType;
        this.source = source;
        this.targets = targets;
        this.targets = targetsHit;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBattleAction : BattleAction
{

    private readonly int basePower;
    private readonly CreatureType damageType;
    private readonly double chanceToHit;

    public DamageBattleAction(TargetClass targetClass, int basePower, CreatureType damageType, double chanceToHit) : base(targetClass)
    {
        this.basePower = basePower;
        this.damageType = damageType;
        this.chanceToHit = chanceToHit;
    }

    public override int execute(BattleActionContext actionContext)
    {
        bool targetsHit = false;

        foreach (BattleCreature target in actionContext.targets)
        {
            if (!target.isKnockedOut())
            {
                if (RandomUtils.checkOdds(chanceToHit * (1 + actionContext.alteredChanceToHit)))
                {
                    double typeMultiplier = damageType.getDamageMultiplierVs(target.creature.getCreatureTypes());

                    target.changeHealth(DamageUtils.calculateDamage(basePower * typeMultiplier,
                                                                    actionContext.source.creature.getStats(),
                                                                    target.creature.getStats()));
                    targetsHit = true;
                }
            }
        }
        return targetsHit ? 0 : 1;
    }

    public override string ToString()
    {
        return "Damage: " + basePower + " Type: " + damageType.name;
    }

    public static BattleAction fromJSONObject(JSONObject json)
    {
        JSONObject inputArr = json.GetField("inputs");
        List<JSONObject> inputList = inputArr.list;
        int targetClassInt = (int)inputList[0].n;
        int basePower = (int)inputList[1].n;
        int damageTypeId = (int)inputList[2].n;
        double chanceToHit = (double)inputList[3].n;

        TargetClass targetClass = (TargetClass)targetClassInt;
        CreatureType creatureType = CreatureType.creatureTypes[(CreatureType.Name)damageTypeId];

        return new DamageBattleAction(targetClass, basePower, creatureType, chanceToHit);
    }
}

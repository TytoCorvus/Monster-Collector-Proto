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

    public override BattleActionResult execute(BattleCreature source, List<BattleCreature> targets, double amp, double hitChanceMultiplier, double alteredChanceForSecondary)
    {
        bool interactableTargets = false;
        int damageDealt = 0;
        List<BattleCreature> hit = new List<BattleCreature>();

        foreach (BattleCreature target in targets)
        {
            if (target.isInteractable())
            {
                interactableTargets = true;
                if (RandomUtils.checkOdds(chanceToHit * (1 + hitChanceMultiplier)))
                {
                    double typeMultiplier = damageType.getDamageMultiplierVs(target.creature.getCreatureTypes());

                    int damage = DamageUtils.calculateDamage(basePower * typeMultiplier,
                                                                    source.creature.getStats(),
                                                                    target.creature.getStats());
                    damageDealt += damage;
                    target.changeHealth(damage);
                    hit.Add(target);
                }
            }
        }

        return new DamageBattleActionResult(interactableTargets, targets.Count > 0, damageDealt, damageType, source, targets, hit);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBattleAction : BattleAction
{
    private List<StatName> statsArray;
    private double buffValue;
    private bool isAdditive;
    private CreatureType.Name creatureType;
    private double chanceToHit;



    public BuffBattleAction(TargetClass targetClass, List<StatName> statsArray, double buffValue,
                            bool isAdditive, CreatureType.Name creatureType, double chanceToHit) : base(targetClass)
    {
        this.statsArray = statsArray;
        this.buffValue = buffValue;
        this.isAdditive = isAdditive;
        this.creatureType = creatureType;
        this.chanceToHit = chanceToHit;
    }


    public override BattleActionResult execute(BattleCreature source, List<BattleCreature> targets, double amp, double hitChanceMultiplier, double alteredChanceForSecondary)
    {
        return null;
    }

    public static BattleAction fromJSONObject(JSONObject json)
    {
        //TODO properly implement
        return null;
    }
}

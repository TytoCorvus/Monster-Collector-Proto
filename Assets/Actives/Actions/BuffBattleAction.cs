using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffBattleAction : BattleAction
{
    private List<CreatureStats.StatName> statsArray;
    private double buffValue;
    private bool isAdditive;
    private CreatureTypeLibrary.CreatureTypeName creatureType;
    private double chanceToHit;

    public BuffBattleAction(TargetClass targetClass, List<CreatureStats.StatName> statsArray, double buffValue,
                            bool isAdditive, CreatureTypeLibrary.CreatureTypeName creatureType, double chanceToHit) : base(targetClass)
    {
        this.statsArray = statsArray;
        this.buffValue = buffValue;
        this.isAdditive = isAdditive;
        this.creatureType = creatureType;
        this.chanceToHit = chanceToHit;
    }


    public override int execute(BattleActionContext actionContext)
    {
        //TODO properly implement status conditions
        return 0;
    }

    public static BattleAction fromJSONObject(JSONObject json)
    {
        //TODO properly implement
        return null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUtils
{

    public static int calculateDamage(double movePower, CreatureStats sourceCreature, CreatureStats receivingCreature)
    {
        int attackerSTR = sourceCreature.getStat(CreatureStats.StatName.STR).get();
        int defenderARM = receivingCreature.getStat(CreatureStats.StatName.ARM).get();
        return (int)(movePower + (attackerSTR - defenderARM));
    }

}

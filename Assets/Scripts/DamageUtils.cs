using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUtils
{

    public static int calculateDamage(double movePower, CreatureStats sourceCreature, CreatureStats receivingCreature)
    {
        int attackerSTR = sourceCreature.getStat(StatName.STR).get();
        int defenderARM = receivingCreature.getStat(StatName.ARM).get();
        return (int)(movePower + (attackerSTR - defenderARM));
    }

}

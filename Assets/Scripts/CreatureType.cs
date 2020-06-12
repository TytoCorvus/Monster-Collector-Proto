using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureType
{

    public readonly int id;

    private readonly string name;

    private readonly string color;

    private readonly List<int> advantage;

    private readonly List<int> resist;

    private readonly List<int> immune;

    public CreatureType(int id, string name, string color, List<int> adv, List<int> res, List<int> imm)
    {
        this.id = id;
        this.name = name;
        this.color = color;
        this.advantage = adv;
        this.resist = res;
        this.immune = imm;
    }

    public double getDamageMultiplierVs(List<CreatureType> creatureTypes)
    {
        int advantages = 0;
        int resists = 0;

        foreach (CreatureType ct in creatureTypes)
        {
            if (ct.immune.Contains(id))
            {
                return 0;
            }
            if (ct.resist.Contains(id))
            {
                resists++;
            }
            if (advantage.Contains(ct.id))
            {
                advantages++;
            }
        }

        return (1 + advantages) / (1 + resists);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureType
{

    public readonly int id;

    private readonly string name;

    private readonly string color;

    private readonly List<int> advantage;

    private readonly List<int> disadvantage;

    private readonly List<int> immune;

    public CreatureType(int id, string name, string color, List<int> adv, List<int> disadv, List<int> imm)
    {
        this.id = id;
        this.name = name;
        this.color = color;
        this.advantage = adv;
        this.disadvantage = disadv;
        this.immune = imm;
    }

}

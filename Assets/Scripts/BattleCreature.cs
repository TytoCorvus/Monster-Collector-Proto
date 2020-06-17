﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCreature : MonoBehaviour
{
    public Creature creature;
    public Owner owner;
    public readonly Focus focus = new Focus(30);
    public readonly List<Status> status = new List<>();
    private bool knockedOut = false;

    private int maxHP { get => maxHP; set => maxHP = value; }

    public int currentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }

    public void applyCreature(Creature creature, Owner owner)
    {
        this.creature = creature;
        this.owner = owner;
        maxHP = creature.getStats().getStat(CreatureStats.StatName.HP).get();
        currentHP = maxHP;
    }

    private int getHP()
    {
        return currentHP;
    }

    public void changeHealth(int amount)
    {
        int newAmount = currentHP + amount;
        int maxHP = creature.getStats().getStat(CreatureStats.StatName.HP).get();
        currentHP = bound(newAmount, 0, maxHP);
        if (currentHP == 0) knockedOut = true;
    }

    public int bound(int newVal, int floor, int ceiling)
    {
        if (ceiling < floor) { throw new System.Exception("bound method in Battle Creature used incorrectly. Ceiling MUST be larger than the floor"); }
        int finalVal = newVal;
        if (newVal < floor) { finalVal = floor; }
        if (finalVal > ceiling) { finalVal = ceiling; }
        return finalVal;
    }

    public bool isKnockedOut()
    {
        return knockedOut;
    }

    public CreatureStats getCurrentStats()
    {

    }
}

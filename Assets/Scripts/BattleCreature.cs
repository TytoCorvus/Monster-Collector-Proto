using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCreature : MonoBehaviour
{
    public const int MAX_FOCUS = 100;
    public Creature creature;
    private bool knockedOut = false;

    public int currentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }
    public int currentFocus
    {
        get { return currentFocus; }
        set { currentFocus = value > MAX_FOCUS ? MAX_FOCUS : value; }
    }

    void Start()
    {
        currentHP = creature.getStats().getStat(CreatureStats.StatName.HP).get();
    }

    private int getHP()
    {
        return currentHP;
    }
    private int getFocus()
    {
        return currentFocus;
    }

    public void changeHealth(int amount)
    {
        int newAmount = currentHP + amount;

        if (newAmount < 0) { newAmount = 0; }
        int maxHP = creature.getStats.getStat(CreatureStats.StatName.HP).get();
        if (newAmount > maxHP) { newAmount = maxHP; }
        currentHP = newAmount;
    }

    public void changeFocus(int amount)
    {
        //int newAmount = 
    }

    public int bound(int newVal, int floor, int ceiling)
    {
        if (ceiling < floor) { throw new System.Exception("bound method in Battle Creature used incorrectly. Ceiling MUST be larger than the floor")}
        int finalVal = newVal;
        if (newVal < floor) { finalVal = floor; }
        if (finalVal > ceiling) { finalVal = ceiling; }
        return finalVal;
    }

    public bool isKnockedOut()
    {
        return knockedOut;
    }
}

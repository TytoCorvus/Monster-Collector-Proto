using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCreature
{
    //TODO make a UI for BattleCreatures
    private BattleCreatureHUD hud;
    public Creature creature;
    public Owner owner;
    public readonly Focus focus;
    public readonly List<Status> status = new List<Status>();
    private bool knockedOut = false;
    private bool onBattlefield = false;

    public BattleCreature(Creature creature, Owner owner, BattleCreatureHUD hud, Watchers watchers)
    {
        this.creature = creature;
        this.focus = new Focus(this.creature.focalPoints, watchers);
        this.owner = owner;
        this.hud = hud;
    }

    public int maxHP { get => maxHP; set => maxHP = value; }
    public int currentHP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }

    public void changeHealth(int changeVal)
    {
        currentHP = bound(currentHP + changeVal, 0, maxHP);
    }

    public void changeFocus(int changeVal)
    {
        focus.alterCurrentFocus(changeVal);
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

    public bool isInteractable()
    {
        //TODO add checks for dodge and whatnot
        return !isKnockedOut();
    }

    public void enterBattlefield(){
        focus.setCurrentFocus(0);
        focus.setEndTurnFocus(true);
        onBattlefield = true;
    }

    public void leaveBattlefield()
    {
        focus.setCurrentFocus(0);
        focus.setEndTurnFocus(true);
        onBattlefield = false;
    }

    public HashSet<CreatureType> getCreatureTypes()
    {
        return creature.getCreatureTypes();
    }

    public CreatureStats getCurrentStats()
    {
        List<Pair<StatName, StatModifier>> focusMods = focus.getCurrentStatChanges();
        return creature.getStats().getStatsWithMods(focusMods);
    }

    public override bool Equals(object obj)
    {
        //TODO complete this for status

        if(!(obj is BattleCreature))
        {
            return false;
        }

        BattleCreature other = (BattleCreature)obj;
        bool isEqual = true;

        isEqual &= creature.Equals(other.creature);
        isEqual &= focus.Equals(other.focus);
        isEqual &= knockedOut == other.knockedOut;
        isEqual &= ((status == null || status.Count == 0) && (other.status == null || other.status.Count == 0)) || status.Count == other.status.Count;
        foreach(Status s in status)
        {
            isEqual &= other.status.Contains(s);
        }

        return isEqual;
    }
}

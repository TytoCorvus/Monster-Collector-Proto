using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature
{
    public List<Move> moveset;
    public FocalPoints focalPoints;
    public Ability creatureAbility;
    public CreatureStats baseStats;

    private CreatureForm baseForm;
    private List<CreatureForm> availableForms;
    private CreatureForm currentForm;

    public Creature(List<Move> moveset, FocalPoints focalPoints, Ability creatureAbility, CreatureStats baseStats, List<CreatureForm> availableForms)
    {
        this.moveset = moveset;
        this.focalPoints = focalPoints;
        this.creatureAbility = creatureAbility;
        this.baseStats = baseStats;
        this.availableForms = availableForms;
        this.baseForm = availableForms[0];
        this.currentForm = availableForms[0];
    }

    public List<CreatureType> getCreatureTypes()
    {
        return currentForm.creatureTypes;
    }

    public CreatureStats getStats()
    {
        CreatureStats statSum = new CreatureStats(baseStats);
        
        foreach(Pair<StatName, StatModifier> statMod in currentForm.statMods)
        {
            statSum.getStat(statMod.getFirst()).setModifier(statMod.getSecond());
        }

        return statSum;
    }

}

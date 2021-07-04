using System;
using System.Collections;
using System.Collections.Generic;

public class Creature
{
    public int creatureId;
    public string creatureName;
    public HashSet<Move> moveset;
    public FocalPoints focalPoints;
    public Ability creatureAbility;
    public CreatureStats baseStats;

    private CreatureForm baseForm;
    private List<CreatureForm> availableForms;
    private CreatureForm currentForm;

    public Creature(int creatureId, string creatureName, HashSet<Move> moveset, FocalPoints focalPoints, Ability creatureAbility, CreatureStats baseStats, CreatureForm baseForm, List<CreatureForm> availableForms)
    {
        this.creatureId = creatureId;
        this.creatureName = creatureName;
        this.moveset = moveset;
        this.focalPoints = focalPoints;
        this.creatureAbility = creatureAbility;
        this.baseStats = baseStats;
        this.availableForms = availableForms;
        this.baseForm = baseForm;
        this.currentForm = baseForm;
    }

    public HashSet<CreatureType> getCreatureTypes()
    {
        return currentForm.creatureTypes;
    }

    public CreatureStats getStats()
    {
        return baseStats.getStatsWithMods(currentForm.statMods);
    }

    public override bool Equals(Object o)
    {
        Creature other = (Creature)o;
        bool isEqual = true;

        isEqual &= creatureId == other.creatureId;
        isEqual &= (moveset == null && other.moveset == null) || moveset.SetEquals(other.moveset);
        isEqual &= (focalPoints == null && other.focalPoints == null) || focalPoints.Equals(other.focalPoints);
        isEqual &= (baseStats == null && other.baseStats == null) || baseStats.Equals(other.baseStats);
        isEqual &= (baseForm == null && other.baseForm == null) || baseForm.Equals(other.baseForm);
        isEqual &= (currentForm == null && other.currentForm == null) || currentForm.Equals(other.baseForm);
        isEqual &= (availableForms == null && other.availableForms == null) || availableForms.Count == other.availableForms.Count;

        if(!(availableForms == null && other.availableForms == null))
        {
            foreach (CreatureForm cf in availableForms)
            {
                isEqual &= other.availableForms.Contains(cf);
            }
        }
        
        return isEqual;
    }

    public static Creature fromJSONObject(JSONObject json)
    {
        int creatureId = (int)json.GetField("creatureId").n;
        string creatureName = json.GetField("creatureName").str;
        CreatureStats baseStats = CreatureStats.fromJSONObject(json.GetField("baseStats"));
        //TODO deserialize Abilities 
        Ability ability = null;
        HashSet<Move> moves = new HashSet<Move>();
        foreach(JSONObject moveName in json.GetField("moves").list)
        {
            string n = moveName.str;
            moves.Add(MoveLibrary.get(n));
        }
        FocalPoints focalPoints = FocalPoints.fromJSONObject(json.GetField("focalPoints"));
        CreatureForm baseForm = CreatureForm.fromJSONObject(json.GetField("baseForm"));
        List<CreatureForm> availableForms = new List<CreatureForm>();
        foreach (JSONObject formJSON in json.GetField("availableForms").list)
        {
            CreatureForm creatureForm = CreatureForm.fromJSONObject(formJSON);
            availableForms.Add(CreatureForm.fromJSONObject(formJSON));
           
        }
        Creature result = new Creature(creatureId, creatureName, moves, focalPoints, ability, baseStats, baseForm, availableForms);
        return result;
    }
}

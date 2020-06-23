using System;
using System.Collections.Generic;

public class CreatureForm
{
    public readonly HashSet<CreatureType> creatureTypes;
    public readonly List<Pair<StatName, StatModifier>> statMods;
    public readonly Ability formAbility;
    public readonly BattleAction revealAction;
    public readonly Move signature;

    public CreatureForm(HashSet<CreatureType> creatureTypes, Ability formAbility, BattleAction revealAction)
    {
        //Only ever used for base form
        this.creatureTypes = creatureTypes;
        this.statMods = new List<Pair<StatName, StatModifier>>();
        this.formAbility = formAbility;
        this.revealAction = revealAction;
        this.signature = null;
    }
    public CreatureForm(HashSet<CreatureType> creatureTypes, List<Pair<StatName, StatModifier>> statMods, Ability formAbility, BattleAction revealAction, Move signature)
    {
        //Used for forms requiring a reveal
        this.creatureTypes = creatureTypes;
        this.statMods = statMods != null ? statMods : new List<Pair<StatName, StatModifier>>();
        this.formAbility = formAbility;
        this.revealAction = revealAction;
        this.signature = signature;
    }

    public override bool Equals(Object o)
    {
        CreatureForm other = (CreatureForm)o;
        bool isEqual = true;

        isEqual &= creatureTypes.Count == other.creatureTypes.Count;
        foreach(CreatureType ct in creatureTypes)
        {
            isEqual &= other.creatureTypes.Contains(ct);
        }

            
        CreatureStats expectedStats = (new CreatureStats()).getStatsWithMods(statMods);
        CreatureStats actualStats = (new CreatureStats()).getStatsWithMods(other.statMods);

        isEqual &= expectedStats.Equals(actualStats); 
        isEqual &= (formAbility == null && other.formAbility == null) || formAbility.Equals(other.formAbility);
        isEqual &= (revealAction == null && other.revealAction == null) || revealAction.Equals(other.revealAction);
        isEqual &= (signature == null && other.signature == null) || signature.Equals(other.signature);
        return isEqual;
    }

    public static CreatureForm fromJSONObject(JSONObject json)
    {
        HashSet<CreatureType> creatureTypes = new HashSet<CreatureType>();
        Ability ability = null;             //"abilityId"
        BattleAction revealAction = null;   //"revealAction"
        Move signature = null;              //"moveId"
        List<Pair<StatName, StatModifier>> statMods;

        JSONObject creatureTypesArray = json.GetField("creatureTypes");
        foreach(JSONObject j in creatureTypesArray.list)
        {
            creatureTypes.Add(CreatureType.creatureTypesByName[j.str]);
        }

        statMods = null;
        if (json.HasField("statMods"))
        {
            statMods = StatModifier.listFromJSONObject(json.GetField("statMods"));
        }

        return new CreatureForm(creatureTypes, statMods, ability, revealAction, signature);
    }
}


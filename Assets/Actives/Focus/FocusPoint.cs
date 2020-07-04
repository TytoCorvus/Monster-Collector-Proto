using System;
using System.Collections.Generic;

public class FocusPoint
{
    private readonly FocusTrigger focusTrigger;
    private readonly BattleAction battleAction;
    private readonly List<Pair<StatName, StatModifier>> statModifiers;
    private readonly string description;
    public FocusPoint(FocusTrigger focusTrigger, BattleAction battleAction, List<Pair<StatName, StatModifier>> statModifiers, string description)
    {
        this.focusTrigger = focusTrigger;
        this.battleAction = battleAction;
        this.statModifiers = statModifiers;
        this.description = description;
    }

    public bool hasActive()
    {
        return focusTrigger != null && battleAction != null;
    }

    public bool hasStatModifier()
    {
        return statModifiers != null && statModifiers.Count != 0;
    }

    public List<Pair<StatName, StatModifier>> getStatModifiers()
    {
        return statModifiers;
    }

    public override string ToString()
    {
        return description;
    }



    public override bool Equals(Object obj)
    {
        if (!(obj is FocusPoint))
            return false;
        FocusPoint other = (FocusPoint)obj;

        bool isEqual = true;

        if(!(statModifiers == null && other.statModifiers == null))
        {
            isEqual &= statModifiers.Count == other.statModifiers.Count;
            isEqual &= (new CreatureStats()).getStatsWithMods(statModifiers).Equals((new CreatureStats()).getStatsWithMods(other.statModifiers));
        }
        
        isEqual &= (battleAction == null && other.battleAction == null) || battleAction.Equals(other.battleAction);
        isEqual &= (focusTrigger == null && other.focusTrigger == null) || focusTrigger.Equals(other.focusTrigger);

        return isEqual;
    }

    public static FocusPoint fromJSONObject(JSONObject json)
    {
        string description = json.GetField("description").str;
        List<Pair<StatName, StatModifier>> statMods = new List<Pair<StatName, StatModifier>>();
        BattleAction action = null;
        FocusTrigger trigger = null;

        if (json.HasField("statMods"))
            statMods = StatModifier.listFromJSONObject(json.GetField("statMods")); 

        if (json.HasField("active"))
        {

        }

        if (json.HasField("activeTrigger"))
        {

        }

        return new FocusPoint(trigger, action, statMods, description);
    }
}

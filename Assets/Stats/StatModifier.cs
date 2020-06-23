
using System;
using System.Collections.Generic;

public class StatModifier
{
    public static StatModifier NEUTRAL_MOD = new StatModifier(0, 1);

    public readonly int additive;
    public readonly double multiplicative;

    public StatModifier(int additive, double multiplicative)
    {
        this.additive = additive;
        this.multiplicative = multiplicative;
    }

    public StatModifier add(StatModifier other)
    {
        return new StatModifier(additive + other.additive, multiplicative * other.multiplicative);
    }

    public int applyToBase(int baseVal)
    {
        return (int)((baseVal + additive) * multiplicative);
    }

    public bool Equals(StatModifier other)
    {
        bool multIsEqual = Math.Abs(other.multiplicative - multiplicative) <= 0.001;
        return other.additive == additive && multIsEqual;
    }

    public override string ToString()
    {
        return "Additive: " + additive + " Multiplicative: " + multiplicative;
    }

    public static StatModifier fromJSONObject(JSONObject json)
    {
        if(json.type != JSONObject.Type.ARRAY)
            throw new System.Exception("StatModifier was passed a JSON object that is not an array");

        return new StatModifier((int)json.list[0].n, (double)json.list[1].n);
    }

    public static List<Pair<StatName, StatModifier>> listFromJSONObject(JSONObject json)
    {
        List<Pair<StatName, StatModifier>> statMods = new List<Pair<StatName, StatModifier>>();
        if (json.HasField("STR"))
            statMods.Add(new Pair<StatName, StatModifier>(StatName.STR, StatModifier.fromJSONObject(json.GetField("STR"))));
        if (json.HasField("ARM"))
            statMods.Add(new Pair<StatName, StatModifier>(StatName.ARM, StatModifier.fromJSONObject(json.GetField("ARM"))));
        if (json.HasField("SPD"))
            statMods.Add(new Pair<StatName, StatModifier>(StatName.SPD, StatModifier.fromJSONObject(json.GetField("SPD"))));
        return statMods;
    }
}
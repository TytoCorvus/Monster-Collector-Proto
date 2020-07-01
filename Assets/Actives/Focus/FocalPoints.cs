using System;
using System.Collections.Generic;

public class FocalPoints
{

    private readonly Dictionary<FocusThreshold, FocusPoint> fp;

    public FocalPoints()
    {
        fp = new Dictionary<FocusThreshold, FocusPoint>();
    }

    public FocalPoints(FocusPoint hazy, FocusPoint alert, FocusPoint inTune, FocusPoint sharp)
    {
        fp = new Dictionary<FocusThreshold, FocusPoint>();
        fp.Add(FocusThreshold.HAZY, hazy);
        fp.Add(FocusThreshold.ALERT, alert);
        fp.Add(FocusThreshold.IN_TUNE, inTune);
        fp.Add(FocusThreshold.SHARP, sharp);
    }

    public List<Pair<FocusPoint, double>> getActiveFocusPoints(FocusThreshold currentThreshold)
    {
        List<Pair<FocusPoint, double>> result = new List<Pair<FocusPoint, double>>();
        switch (currentThreshold)
        {
            case FocusThreshold.SHARP:
                result.Add(new Pair<FocusPoint, double>(fp[FocusThreshold.SHARP], 2));
                goto case FocusThreshold.IN_TUNE;
            case FocusThreshold.IN_TUNE:
                result.Add(new Pair<FocusPoint, double>(fp[FocusThreshold.IN_TUNE], 1.67));
                goto case FocusThreshold.ALERT;
            case FocusThreshold.ALERT:
                result.Add(new Pair<FocusPoint, double>(fp[FocusThreshold.ALERT], 1.33));
                goto case FocusThreshold.HAZY;
            case FocusThreshold.HAZY:
                result.Add(new Pair<FocusPoint, double>(fp[FocusThreshold.HAZY], 1));
                break;
        }
        return result;
    }

    public List<Pair<StatName, StatModifier>> getFocusStatChanges(FocusThreshold currentThreshold)
    {
        List<Pair<StatName, StatModifier>> statMods = new List<Pair<StatName, StatModifier>>();
        List<Pair<FocusPoint, double>> activeFocusPoints = getActiveFocusPoints(currentThreshold);

        foreach (Pair<FocusPoint, double> pair in activeFocusPoints)
        {
            if (pair.getFirst().hasStatModifier())
            {
                if(pair.getSecond() == 1)
                {
                    statMods.AddRange(pair.getFirst().getStatModifiers());
                }else
                {
                   List<Pair<StatName, StatModifier>> untouchedMods = pair.getFirst().getStatModifiers();

                   foreach(Pair<StatName, StatModifier> nameModPair in untouchedMods)
                    {
                        StatModifier mod = nameModPair.getSecond();

                        int newAdd = (int)(mod.additive * pair.getSecond());
                        double newMult = 1;
                        if(mod.multiplicative > 1)
                        {
                           newMult = (mod.multiplicative - 1) * pair.getSecond() + 1;
                        }
                        if(mod.multiplicative < 1)
                        {
                            newMult = Math.Pow(mod.multiplicative, pair.getSecond());
                        }

                        statMods.Add(new Pair<StatName, StatModifier>(nameModPair.getFirst(), new StatModifier(newAdd, newMult)));
                    }
                }
          
            }

        }

        return statMods;
    }

    public override bool Equals(Object obj)
    {
        if (!(obj is FocalPoints))
            return false;
        FocalPoints other = (FocalPoints)obj;

        bool isEqual = true;
        isEqual &= fp[FocusThreshold.HAZY].Equals(other.fp[FocusThreshold.HAZY]);
        isEqual &= fp[FocusThreshold.ALERT].Equals(other.fp[FocusThreshold.ALERT]);
        isEqual &= fp[FocusThreshold.IN_TUNE].Equals(other.fp[FocusThreshold.IN_TUNE]);
        isEqual &= fp[FocusThreshold.SHARP].Equals(other.fp[FocusThreshold.SHARP]);
        return isEqual;
    }

    public static FocalPoints fromJSONObject(JSONObject json)
    {
        if(json.type != JSONObject.Type.ARRAY)
        {
            throw new System.Exception("FocalPoints deserialization failed: json is not array");
        }
        if(json.list.Count != 4)
        {
            throw new System.Exception("FocalPoints deserialization failed: item count is not 4");
        }

        List<FocusPoint> points = new List<FocusPoint>();
        foreach(JSONObject j in json.list)
        {
            points.Add(FocusPoint.fromJSONObject(j));
        }

        return new FocalPoints(points[0], points[1], points[2], points[3]);
    }
}

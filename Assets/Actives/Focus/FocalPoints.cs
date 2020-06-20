using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoints
{

    private readonly Dictionary<FocusThreshold, FocusPoint> fp;

    public FocalPoints()
    {
        fp = new Dictionary<FocusThreshold, FocusPoint>();
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

}

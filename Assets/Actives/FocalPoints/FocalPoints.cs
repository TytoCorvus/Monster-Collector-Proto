using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoints
{

    private readonly Dictionary<FocusThreshold, FocusPoint> fp;

    public FocalPoints()
    {
        fp = new Dictionary<>();
    }

    public List<Pair<FocusPoint, double>> getActiveFocusPoints(FocusThreshold currentThreshold)
    {
        List<Pair<FocusPoint, double>> result = new List<>();
        switch (currentThreshold)
        {
            case FocusThreshold.SHARP:
                result.Add(new Pair<>(fp[FocusThreshold.SHARP], 2));
            case FocusThreshold.IN_TUNE:
                result.Add(new Pair<>(fp[FocusThreshold.IN_TUNE], 1.67));
            case FocusThreshold.ALERT:
                result.Add(new Pair<>(fp[FocusThreshold.ALERT], 1.33));
            case FocusThreshold.HAZY:
                result.Add(new Pair<>(fp[FocusThreshold.HAZY], 1));
                break;
            case default:
                break;
        }
        return result;
    }
}

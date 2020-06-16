using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocalPoints
{

    private readonly Dictionary<Focus.FocusThreshold, FocusPoint> fp;

    public FocalPoints()
    {
        fp = new Dictionary<>();
    }

    public List<Pair<FocusPoint, double>> getActiveFocusPoints(Focus.FocusThreshold currentThreshold)
    {
        List<Pair<FocusPoint, double>> result = new List<>();
        switch (currentThreshold)
        {
            case Focus.FocusThreshold.SHARP:
                result.Add(fp[Focus.FocusThreshold.SHARP, 2]);
            case Focus.FocusThreshold.IN_TUNE:
                //result.Add(fp[])
        }
    }
}

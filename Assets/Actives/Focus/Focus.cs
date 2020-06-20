using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus
{
    public const int MAX_FOCUS = 100;

    private FocusThreshold currentThreshold;
    private FocalPoints focalPoints;
    private int currentFocus;

    public Focus()
    {
        this.currentFocus = 30;
    }

    public Focus(FocalPoints focalPoints)
    {
        this.currentFocus = 30;
        this.focalPoints = focalPoints;
    }

    public int getCurrentFocus() { return currentFocus; }
    public List<BattleAction> alterCurrentFocus(int value, BattleCreature owner)
    {
        List<Pair<FocusPoint, double>> previouslyActive = focalPoints.getActiveFocusPoints(currentThreshold);

        currentFocus += value;
        currentFocus = bound_int(currentFocus, 0, MAX_FOCUS);
        updateCurrentThreshold();

        List<Pair<FocusPoint, double>> newlyActive = focalPoints.getActiveFocusPoints(currentThreshold);

        if (previouslyActive.Count == newlyActive.Count) { return null; }
        else if (previouslyActive.Count > newlyActive.Count)
        {
            //Deactivate all of the FocusPoints that are no longer active
            //TODO make this not dependent on the order returned from FocalPoints

        } else
        {
            //Activate all of the FocusPoints that are newly active
            //TODO make this not dependent on the order returned from FocalPoints
        }

        //TODO make this return actual BattleActions to occur (Not required for stat-boosting focus effects)
        return new List<BattleAction>();
    }

    public FocusThreshold getCurrentThreshold() { return currentThreshold; }

    public void updateCurrentThreshold()
    {
        FocusThreshold result = FocusThreshold.SHARP;
        if (currentFocus <= 0) { result = FocusThreshold.EMPTY; }
        else if (currentFocus > 0 && currentFocus < 50) { result = FocusThreshold.HAZY; }
        else if (currentFocus >= 50 && currentFocus < 80) { result = FocusThreshold.ALERT; }
        else if (currentFocus >= 80 && currentFocus < 100) { result = FocusThreshold.IN_TUNE; }
        currentThreshold = result;
    }

    public int bound_int(int newVal, int floor, int ceiling)
    {
        if (ceiling < floor) { throw new System.Exception("bound method in Focus used incorrectly. Ceiling MUST be larger than the floor"); }
        int finalVal = newVal;
        if (newVal < floor) { finalVal = floor; }
        if (finalVal > ceiling) { finalVal = ceiling; }
        return finalVal;
    }

    public List<Pair<StatName, StatModifier>> getCurrentStatChanges()
    {
        return focalPoints.getFocusStatChanges(currentThreshold);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus
{
    public const int MAX_FOCUS = 100;

    private FocusThreshold currentThreshold;
    private int currentFocus;

    public Focus()
    {
        this.currentFocus = 0;
    }

    public Focus(int startingFocus)
    {
        this.currentFocus = startingFocus;
    }

    public int getCurrentFocus() { return currentFocus; }
    public void alterCurrentFocus(int value)
    {
        currentFocus += value;
        currentFocus = bound_int(currentFocus, 0, MAX_FOCUS);
        updateCurrentThreshold();
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

    public enum FocusThreshold
    {
        EMPTY,
        HAZY,
        ALERT,
        IN_TUNE,
        SHARP
    }
}

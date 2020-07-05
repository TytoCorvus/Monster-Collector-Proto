﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Focus : ITurnPhaseListener
{
    public const int MAX_FOCUS = 100;

    private FocusThreshold currentThreshold;
    private FocalPoints focalPoints;
    private int currentFocus;
    private int focusPerUpdate;
    private bool endTurnFocus;
    private readonly Watchers watcher;

    public Focus()
    {
        this.currentFocus = 30;
        this.focusPerUpdate = 10;
        this.endTurnFocus = false;
        this.watcher = null;
        updateCurrentThreshold();
    }

    public Focus(FocalPoints focalPoints, Watchers watcher)
    {
        this.currentFocus = 30;
        this.focusPerUpdate = 10;
        endTurnFocus = false;
        updateCurrentThreshold();
        this.focalPoints = focalPoints;
        subscribe(watcher.turnPhaseWatcher);
    }

    public void subscribe(TurnPhaseWatcher watcher)
    {
        watcher.listen(this, TurnPhase.END);
    }

    public void unsubscribe()
    {
        watcher.turnPhaseWatcher.deafen(this, TurnPhase.END);
    }

    public bool isListeningFor(TurnPhase phase)
    {
        return phase == TurnPhase.END;
    }

    public BattleActionContext respond(TurnPhase phase)
    {
        return new BattleActionContext(new ChangeFocusBattleAction(TargetClass.SELF, focusPerUpdate), null, null, 1, 1);
    }

    public int getCurrentFocus() { return currentFocus; }
    public void setCurrentFocus(int value) { currentFocus = value; updateCurrentThreshold(); }

    public void setEndTurnFocus(bool val)
    {
        endTurnFocus = val;
    }
    public void alterCurrentFocus(int value)
    {
        List<Pair<FocusPoint, double>> previouslyActive = focalPoints.getActiveFocusPoints(currentThreshold);

        currentFocus += value;
        currentFocus = bound_int(currentFocus, 0, MAX_FOCUS);
        updateCurrentThreshold();

        List<Pair<FocusPoint, double>> newlyActive = focalPoints.getActiveFocusPoints(currentThreshold);

        if (previouslyActive.Count > newlyActive.Count)
        {
            //Deactivate all of the FocusPoints that are no longer active
            //TODO make this not dependent on the order returned from FocalPoints

        } else
        {
            //Activate all of the FocusPoints that are newly active
            //TODO make this not dependent on the order returned from FocalPoints
        }
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

    public override bool Equals(object obj)
    {
        if (!(obj is Focus))
            return false;

        Focus other = (Focus)obj;
        bool isEqual = true;



        return base.Equals(obj);
    }
}

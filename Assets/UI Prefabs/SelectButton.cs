using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton<T>
{
    public T returnValue;
    public Color buttonColor;
    public string displayText;
    public MenuResult<T> result;
    public SelectButton(T returnValue, Color buttonColor, string displayText, MenuResult<T> result = null) {
        this.returnValue = returnValue;
        this.buttonColor = buttonColor;
        this.displayText = displayText;
        this.result = result;
    }
}

public enum ButtonDisplayType
{
    TEXT,
    IMAGE
}

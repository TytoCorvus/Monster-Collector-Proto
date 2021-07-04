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


    public static SelectButton<Move> create(Move m)
    {
        return new SelectButton<Move>(m, colorFromRgb(m.creatureType.color), m.name);
    }

    private static Color32 colorFromRgb(string colorString)
    {
        int r = hexToRGB(colorString.Substring(0, 2));
        int g = hexToRGB(colorString.Substring(2, 2));
        int b = hexToRGB(colorString.Substring(4, 2));
        return new Color32((byte)r, (byte)g, (byte)b, (byte)255);
    }

    private static int hexToRGB(string twoDigitHex)
    {
        int first;
        int second;
        bool couldParseFirst = Int32.TryParse(twoDigitHex.Substring(0, 1), out first);
        if (!couldParseFirst)
        {
            first = parseSingle(twoDigitHex.Substring(0, 1));
        }
        first = first * 16;
        bool couldParseSecond = Int32.TryParse(twoDigitHex.Substring(1, 1), out second);
        if (!couldParseSecond)
        {
            second = parseSingle(twoDigitHex.Substring(1, 1));
        }
        return first + second;
    }

    private static int parseSingle(string str)
    {
        int first;
        switch (str.Substring(0, 1))
        {
            case "a":
                first = 10;
                break;
            case "b":
                first = 11;
                break;
            case "c":
                first = 12;
                break;
            case "d":
                first = 13;
                break;
            case "e":
                first = 14;
                break;
            case "f":
                first = 15;
                break;
            default:
                throw new System.Exception("Couldn't parse RBG values");
        }
        return first;
    }
}

public enum ButtonDisplayType
{
    TEXT,
    IMAGE
}

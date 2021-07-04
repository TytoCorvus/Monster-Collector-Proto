using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.WindowsStandalone;
using UnityEngine;
using UnityEngine.UI;

public class UIUtility 
{
    public static SelectButton<Move> Build(Move m)
    {
        return new SelectButton<Move>(m, colorFromHexString(m.creatureType.color), m.name);
    }

    private static UnityEngine.Color colorFromHexString(string str)
    {
        int r = hexToRGB(str.Substring(0, 2));
        int g = hexToRGB(str.Substring(2, 2));
        int b = hexToRGB(str.Substring(4, 2));
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

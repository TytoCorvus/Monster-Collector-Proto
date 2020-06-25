using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenuUI : MonoBehaviour
{
    public List<GameObject> moveButtons;

    private List<Move> availableMoves = new List<Move>();
    void Start()
    {
        LibraryLoader.loadMoveLibrary();
        availableMoves.Add(MoveLibrary.get("Strike"));
        availableMoves.Add(MoveLibrary.get("Flare"));
        availableMoves.Add(MoveLibrary.get("Slam"));
        availableMoves.Add(MoveLibrary.get("Waste Away"));
        display();
    }

    public void display()
    {
        Debug.Log("Displaying");
        int numMoves = availableMoves.Count;

        for(int i = 0; i < moveButtons.Count; i++)
        {
            if(i > numMoves - 1)
                moveButtons[i].SetActive(false);
            else
            {
                moveButtons[i].SetActive(true);
                Image image = moveButtons[i].GetComponent(typeof(Image)) as Image;
                Text buttonText = moveButtons[i].transform.GetChild(0).GetComponent(typeof(Text)) as Text;

                buttonText.text = availableMoves[i].name;
                string colorString = availableMoves[i].creatureType.color;
                int r = hexToRGB(colorString.Substring(0, 2));
                int g = hexToRGB(colorString.Substring(2, 2));
                int b = hexToRGB(colorString.Substring(4, 2));
                image.color = new Color32((byte)r, (byte)g, (byte)b, (byte)255);
            } 
        }
    }

    public int hexToRGB(string twoDigitHex)
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
        if(!couldParseSecond)
        {
            second = parseSingle(twoDigitHex.Substring(1, 1));
        }
        return first + second;
    }

    private int parseSingle(string str)
    {
        int first;
        switch (str.Substring(0, 1)){
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

﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LibraryLoader
{
    private static string basePath;
    private static bool moveLibraryLoaded = false;
    // Start is called before the first frame update

    public static void loadMoveLibrary()
    {
        if (!moveLibraryLoaded)
        {
            basePath = Application.dataPath + "/DataLibrary/";

            string json = readEntireFile("moveLib");
            JSONObject moveLibraryJson = JSONObject.Create(json);
            foreach (JSONObject j in moveLibraryJson.list)
            {
                Move m = Move.fromJSONObject(j);
                MoveLibrary.loadDictionary(m.id, m.name, m);
            }
            moveLibraryLoaded = true;
        } 
    }

    public static List<Creature> loadTestCreatures()
    {
        basePath = Application.dataPath + "/DataLibrary/";

        string json = readEntireFile("creatures");

        List<Creature> creatures = new List<Creature>();
        foreach (JSONObject creature in JSONObject.Create(json).list)
            creatures.Add(Creature.fromJSONObject(creature));

        return creatures;
    }

    private static string readEntireFile(string filePath)
    {
        StreamReader streamReader = new StreamReader(basePath + filePath + ".json");
        return streamReader.ReadToEnd();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LibraryLoader : MonoBehaviour
{
    private string basePath;
    // Start is called before the first frame update
    void Start()
    {
        basePath = Application.dataPath + "/DataLibrary/";
        loadMoveLibrary();
    }

    public void loadMoveLibrary()
    {
        string json = readEntireFile("moveLib");
        JSONObject moveLibraryJson = JSONObject.Create(json);
        foreach (JSONObject j in moveLibraryJson.list)
        {
            Move m = Move.fromJSONObject(j);
            MoveLibrary.loadDictionary(m.id, m.name, m);

            Debug.Log(m.ToString());
        }


    }

    private string readEntireFile(string filePath)
    {
        StreamReader streamReader = new StreamReader(basePath + filePath + ".json");
        return streamReader.ReadToEnd();
    }
}

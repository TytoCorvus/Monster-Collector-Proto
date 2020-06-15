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
        beginLoad();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void beginLoad()
    {
        // TextAsset targetFile = Resources.Load<TextAsset>(filePath);
        // Debug.Log(targetFile.name);

        string fileName = "battleActionLib";

        Debug.Log("Attempting to open the file at location : " + basePath + fileName);
        StreamReader streamReader = new StreamReader(basePath + fileName + ".json");
        string json = streamReader.ReadToEnd();

        List<BattleAction> battleActions = BattleActionLoader.battleActionLibraryFromJson(JSONObject.Create(json));
    }
}

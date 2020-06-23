using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public GameObject battleCreatureUIPrefab;
    public GameObject battleMenuUIPrefab;
    public Canvas baseCanvas;

    private readonly RectTransform allyUIPosition;
    private readonly RectTransform enemyUIPosition;

    public GameObject allyUI;
    public GameObject enemyUI;

    // Start is called before the first frame update
    void Start()
    {

        GameObject allyUI = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
        allyUI.name = "Ally UI";
        GameObject enemyUI = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
        enemyUI.name = "Enemy UI";

        ((RectTransform)allyUI.transform).localPosition = new Vector3(-150f, -110f, 0f);
        ((RectTransform)enemyUI.transform).localPosition = new Vector3(150f, 110f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

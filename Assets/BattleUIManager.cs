using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour
{
    public GameObject battleCreatureUIPrefab;
    public GameObject battleMenuUIPrefab;
    public GameObject messageBoxUIPrefab;
    public Canvas baseCanvas;

    private readonly RectTransform allyUIPosition;
    private readonly RectTransform enemyUIPosition;

    public GameObject allyUI;
    public GameObject enemyUI;
    public GameObject battleMenuUI;
    public MessageBoxScript messageBoxUI;

    private BattlefieldPositionManager positionManager;

    // Start is called before the first frame update
    void Start()
    {

        allyUI = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
        allyUI.name = "Ally UI";
        enemyUI = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
        enemyUI.name = "Enemy UI";
        battleMenuUI = Instantiate(battleMenuUIPrefab, baseCanvas.transform);
        battleMenuUI.name = "Battle Menu";

        ((RectTransform)allyUI.transform).localPosition = new Vector3(-150f, -110f, 0f);
        ((RectTransform)enemyUI.transform).localPosition = new Vector3(150f, 110f, 0f);
        ((RectTransform)battleMenuUI.transform).anchorMin = new Vector2(0.55f, 0f);
        ((RectTransform)battleMenuUI.transform).anchorMax = new Vector2(1f, 0.4f);

        battleMenuUI.SetActive(false);

        messageBoxUI = Instantiate(messageBoxUIPrefab, baseCanvas.transform).GetComponent<MessageBoxScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(BattlefieldPositionManager positionManager)
    {
        this.positionManager = positionManager;
    }

    public void generateBattleMenu(BattleCreature battleCreature)
    {

    }

    public void createTextBox(string message, bool requireInput)
    {
        messageBoxUI.clear();
        messageBoxUI.setVisible(true);
        messageBoxUI.enqueueText(message, requireInput);
    }

    public void removeTextBox()
    {
        messageBoxUI.clear();
        messageBoxUI.setVisible(false);
    }
}

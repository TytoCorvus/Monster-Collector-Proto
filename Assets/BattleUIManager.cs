using System;
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
    private Dictionary<BattlefieldPosition, GameObject> creatureUI = new Dictionary<BattlefieldPosition, GameObject>();


    public UIState uiState;
    public GameObject battleMenuUI;
    public MessageBoxScript messageBoxUI;

    private BattlefieldPositionManager positionManager;

    public void setup(BattlefieldPositionManager positionManager)
    {
        this.positionManager = positionManager;
        updateAllUI();
        messageBoxUI = Instantiate(messageBoxUIPrefab, baseCanvas.transform).GetComponent<MessageBoxScript>();
        messageBoxUI.clear();
        messageBoxUI.setVisible(false);

        battleMenuUI = Instantiate(battleMenuUIPrefab, baseCanvas.transform);
        battleMenuUI.name = "Battle Menu";
        ((RectTransform)battleMenuUI.transform).anchorMin = new Vector2(0.55f, 0f);
        ((RectTransform)battleMenuUI.transform).anchorMax = new Vector2(1f, 0.4f);
        battleMenuUI.SetActive(false);
    }

    public void updateAllUI()
    {
        List<BattlefieldPosition> remaining = new List<BattlefieldPosition>(positionManager.getPositions().Keys);

        foreach(KeyValuePair<BattlefieldPosition, BattleCreature> creaturePosition in positionManager.getPositions())
        {

            if (!creatureUI.ContainsKey(creaturePosition.Key))
            {
                GameObject obj = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
                creatureUI.Add(creaturePosition.Key, obj);
                placeCreatureUI(obj, creaturePosition.Key);
            }

            creatureUI[creaturePosition.Key].SetActive(true);
            BattleCreatureHUD creatureHUD = creatureUI[creaturePosition.Key].GetComponent<BattleCreatureHUD>();
            if (creaturePosition.Value != null)
            {
                creatureHUD.updateTo(creaturePosition.Value);
            }
            else
                creatureUI[creaturePosition.Key].SetActive(false);
            
            remaining.Remove(creaturePosition.Key);
        }

        foreach(BattlefieldPosition pos in remaining)
        {
            GameObject obj = creatureUI[pos];
            obj.SetActive(false);
        }
    }

    public IEnumerator waitUntilUpdatesComplete()
    {

        yield return messageBoxUI.waitUntilQueueEmpty();
    }

    private void placeCreatureUI(GameObject creatureUI, BattlefieldPosition bp)
    {
        Vector3 position = new Vector3();
        //TODO make more flexible
        if(bp.Equals(new BattlefieldPosition(0, BattlefieldPosition.PositionType.PRIMARY, 0)))
            position = new Vector3(-150f, -110f, 0f);
        else if(bp.Equals(new BattlefieldPosition(1, BattlefieldPosition.PositionType.PRIMARY, 0)))
            position = new Vector3(150f, 110f, 0f);

        ((RectTransform)creatureUI.transform).localPosition = position;
    }

    public void setShowCreatureUi(Boolean showCreatureUi)
    {
        foreach (KeyValuePair<BattlefieldPosition, BattleCreature> creaturePosition in positionManager.getPositions())
        {

            if (!creatureUI.ContainsKey(creaturePosition.Key))
            {
                GameObject obj = Instantiate(battleCreatureUIPrefab, baseCanvas.transform);
                creatureUI.Add(creaturePosition.Key, obj);
                placeCreatureUI(obj, creaturePosition.Key);
            }
            creatureUI[creaturePosition.Key].SetActive(showCreatureUi);
        }
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

    public void addMessage(string message, bool requireInput)
    {
        messageBoxUI.enqueueText(message, requireInput);
    }

    public void removeTextBox()
    {
        messageBoxUI.clear();
        messageBoxUI.setVisible(false);
    }

    public IEnumerator getMoveSelection(List<Move> moveList, Action<MoveContext> callback)
    {


        battleMenuUI.SetActive(true);
        yield return new WaitForSeconds(2);
        battleMenuUI.SetActive(false);
        callback(new MoveContext());


    } 

    public void updateState(UIState newState)
    {
        switch (newState)
        {
            case UIState.EMPTY:
                break;
            case UIState.CREATURE_UI:
                break;
            case UIState.MESSAGE_BOX:
                break;
            case UIState.ACTION_SELECT:
                break;
            case UIState.TARGET_SELECT:
                break;
            default:
                break;
        }
    }

    public enum UIState
    {
        EMPTY,
        CREATURE_UI,
        MESSAGE_BOX,
        ACTION_SELECT,
        MOVE_SELECT,
        TARGET_SELECT
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Move
{
    public readonly int id;
    public readonly string name;
    public readonly MoveClass moveClass;
    public readonly List<BattleAction> battleActions;

    public readonly int focusChange;
    public readonly int healthChange;

    public Move(int id, string name, MoveClass moveClass, List<BattleAction> battleActions, int focusChange, int healthChange)
    {
        this.id = id;
        this.name = name;
        this.moveClass = moveClass;
        this.battleActions = battleActions;
        this.focusChange = focusChange;
        this.healthChange = healthChange;
    }

    public bool canExecute(BattleActionContext context)
    {
        BattleCreature source = context.source;
        //TODO Update logic to require targets from all reqired BattleActions based on the context or list of contexts
        return !(source.isKnockedOut()) &&
               source.focus.getCurrentFocus() >= focusChange &&
               source.currentHP >= healthChange;
    }

    public void applyCosts(BattleCreature source)
    {
        source.changeHealth(healthChange);
        source.focus.alterCurrentFocus(focusChange);
    }

    public string ToString()
    {
        StringBuilder sb = new StringBuilder("Move: " + name + " BattleActions: ");
        foreach (BattleAction ba in battleActions)
        {
            sb.Append("\nBattleAction: " + ba.ToString());
        }
        return sb.ToString();
    }

    public static Move fromJSONObject(JSONObject json)
    {
        int id;
        string name;
        int moveClassId;
        List<BattleAction> battleActions;
        int focusChange;
        int healthChange;
        json.GetField(out id, "id", -1);
        json.GetField(out name, "name", "");
        json.GetField(out moveClassId, "moveClass", -1);
        json.GetField(out focusChange, "focusChange", int.MinValue);
        json.GetField(out healthChange, "healthChange", int.MinValue);
        battleActions = BattleActionLoader.battleActionListFromJson(json.GetField("actionList"));

        Debug.Log(battleActions.Count);

        return new Move(id, name, (MoveClass)moveClassId, battleActions, focusChange, healthChange);
    }

    public enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }
}

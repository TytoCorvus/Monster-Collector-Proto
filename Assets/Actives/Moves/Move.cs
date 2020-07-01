using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

public class Move
{
    public readonly int id;
    public readonly string name;
    public readonly string description;
    public readonly MoveClass moveClass;
   // public readonly MovePattern movePattern;
    public readonly List<BattleAction> battleActions;
    public readonly CreatureType creatureType;
    public readonly int priority;
    public readonly int focusChange;
    public readonly int healthChange;

    public Move(int id, string name, string description, MoveClass moveClass, List<BattleAction> battleActions, CreatureType creatureType, int priority, int focusChange, int healthChange)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.moveClass = moveClass;
        this.battleActions = battleActions;
        this.creatureType = creatureType;
        this.priority = priority;
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
        //TODO update battlecreature health management
        //source.changeHealth(healthChange);
        source.focus.alterCurrentFocus(focusChange, null);
    }

    public override string ToString()
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
        int id = (int)json.GetField("id").n;
        string name = json.GetField("name").str;
        string description = json.GetField("description").str;
        int moveClassId = (int)json.GetField("moveClass").n;
        List<BattleAction> battleActions = BattleActionLoader.battleActionListFromJson(json.GetField("actionList"));
        int priority = (int)json.GetField("priority").n;
        int focusChange = (int)json.GetField("focusChange").n;
        int healthChange = (int)json.GetField("healthChange").n;
        CreatureType creatureType = CreatureType.creatureTypesByName[json.GetField("type").str];

        UnityEngine.Debug.Log("Deserialized " + name);

        return new Move(id, name, description, (MoveClass)moveClassId, battleActions, creatureType, priority, focusChange, healthChange);
    }

    public enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }
}

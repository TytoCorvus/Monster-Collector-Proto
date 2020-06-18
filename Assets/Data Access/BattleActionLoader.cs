using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionLoader
{
    public static List<BattleAction> battleActionListFromJson(JSONObject arrayAsJson)
    {
        if (arrayAsJson.type != JSONObject.Type.ARRAY)
        {
            throw new System.Exception("There was an error parsing BattleActions");
        }

        List<BattleAction> actionList = new List<BattleAction>();

        foreach (JSONObject j in arrayAsJson.list)
        {
            int id;
            string name;
            BattleAction result = null;
            j.GetField(out id, "actionId", -1);
            j.GetField(out name, "name", "");
            switch ((BATTLE_ACTION_MAPPING)id)
            {
                case BATTLE_ACTION_MAPPING.DAMAGE:
                    result = DamageBattleAction.fromJSONObject(j);
                    break;
                case BATTLE_ACTION_MAPPING.STATUS:
                    result = StatusBattleAction.fromJSONObject(j);
                    break;
                case BATTLE_ACTION_MAPPING.BUFF:
                    result = BuffBattleAction.fromJSONObject(j);
                    break;
                case BATTLE_ACTION_MAPPING.COMPOSITE:
                    result = BattleActionsSharingContext.fromJSONObject(j);
                    break;
            }

            if (result != null) actionList.Add(result);
        }

        return actionList;
    }

    public enum BATTLE_ACTION_MAPPING
    {
        DAMAGE = 0,
        STATUS = 1,
        BUFF = 2,
        COMPOSITE = 3
    }
}

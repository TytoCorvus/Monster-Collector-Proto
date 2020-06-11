using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    private BattleCreature playerCreature;
    private BattleCreature enemyCreature;

    public void takeTurn(List<Move> turns)
    {

    }

    public List<BattleCreature> getTurnOrder()
    {
        return null;
    }

    public List<Pair<BattleAction, BattleActionContext>> getActionContext(Move move, BattleCreature source)
    {
        return new List<Pair<BattleAction, BattleActionContext>>();
    }
}

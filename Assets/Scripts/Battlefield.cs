using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlefield : MonoBehaviour
{
    public int playerSize = 1;
    public int enemySize = 1;
    public List<BattleCreature> playerCreatures;
    private List<BattleCreature> enemyCreatures;

    public void takeTurn(List<Move> turns)
    {

    }

    public List<BattleCreature> getTurnOrder()
    {
        //TODO Make this work as intended, based off of speed
        List<BattleCreature> order = new List<BattleCreature>();
        order.AddRange(playerCreatures);
        order.AddRange(enemyCreatures);
        return order;
    }

    public List<Pair<BattleAction, BattleActionContext>> getActionContext(Move move, BattleCreature source)
    {

        return new List<Pair<BattleAction, BattleActionContext>>();
    }

    public bool isBattleOver()
    {
        return false;
    }
}

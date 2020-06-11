using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCreature : MonoBehaviour
{
    public Creature creature;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private int getHP()
    {
        return creature.currentHP;
    }
    private int getFocus()
    {
        return creature.currentFocus;
    }

}

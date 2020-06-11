using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move
{

    public Move(MoveClass moveClass, TargetClass )
    {

    }


    public void execute()
    {

    }

    public static enum MoveClass
    {
        ATTACK = 0,
        STATUS = 1
    }

    public static enum TargetClass
    {
        ENEMY_SINGLE = 0,
        ENEMY_ALL = 1,
        SELF = 2,
        ALLY = 3,
        ALLY_ALL = 4,
        ALL = 5
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomUtils
{
    public static float next()
    {
        return Random.value;
    }

    public static float nextInRange(float a, float b)
    {
        return Random.Range(a, b);
    }

    public static bool lessThanRandomInRange(double a, float b, float c)
    {
        return a < (double)nextInRange(b, c);
    }

    public static bool checkOdds(double a)
    {
        return a > (double)nextInRange(0, 1);
    }
}

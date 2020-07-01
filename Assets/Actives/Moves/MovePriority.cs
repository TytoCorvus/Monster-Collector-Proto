using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePriority : ICompareTo<MovePriority>
{
    public readonly int priority;
    public readonly int sourceSpeed;

    public MovePriority(int priority, int sourceSpeed)
    {
        this.priority = priority;
        this.sourceSpeed = sourceSpeed;
    }

    public int CompareTo(MovePriority other)
    {
        if (this.Equals(other))
            return 0;
        if (this.priority != other.priority)
            return this.priority - other.priority;
        return other.sourceSpeed - this.sourceSpeed;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is MovePriority))
            return false;
        MovePriority other = (MovePriority)obj;

        return other.priority == priority && other.sourceSpeed == sourceSpeed;
    }
}

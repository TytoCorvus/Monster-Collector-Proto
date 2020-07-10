using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICompareTo<T>
{
    //Returns negative if comparatively before, and positive if after. Returns 0 if equal.
    int CompareTo(T other);
}

using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class MenuResult<T>
{
    private bool collected = false;
    private T value;

    public void set(T newValue)
    {
        value = newValue;
        collected = true;
    }

    private bool isReady()
    {
        return collected;
    }

    public async Task<T> getResult()
    {
        while (!isReady())
        {
            await Task.Yield();
        }

        return value;
    }
}

using System.Runtime.Remoting.Messaging;
using UnityEngine.UIElements.Experimental;

public class Stat
{
    private readonly int baseVal;
    public StatModifier modifier { get => modifier; set => modifier = value; }
    public Stat(int baseVal)
    {
        this.baseVal = baseVal;
        this.modifier = new StatModifier();
    }

    public int getBase()
    {
        return baseVal;
    }

    public int get()
    {
        return (int)((baseVal + modifier.getAdditive()) * modifier.getMultiplicative());
    }

    public void setModifier(StatModifier statModifier)
    {
        this.modifier = statModifier;
    }

    public int applyModifier(StatModifier statModifier)
    {

    }
}
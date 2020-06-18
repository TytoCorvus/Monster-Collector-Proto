public class Stat
{
    private readonly int baseVal;
    private StatModifier modifier;
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
}
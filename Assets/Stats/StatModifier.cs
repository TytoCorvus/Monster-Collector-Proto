
public class StatModifier
{
    public static StatModifier NEUTRAL_MOD = new StatModifier(0, 1);

    public readonly int additive;
    public readonly double multiplicative;

    public StatModifier(int additive, double multiplicative)
    {
        this.additive = additive;
        this.multiplicative = multiplicative;
    }

    public StatModifier add(StatModifier other)
    {
        return new StatModifier(additive + other.additive, multiplicative * other.multiplicative);
    }

    public int applyToBase(int baseVal)
    {
        return (int)((baseVal + additive) * multiplicative);
    }
}
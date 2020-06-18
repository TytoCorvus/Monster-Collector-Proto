public class StatModifier
{
    private int additive;
    private double multiplicative;

    public StatModifier()
    {
        this.additive = 0;
        this.multiplicative = 1;
    }

    public int getAdditive()
    {
        return additive;
    }

    public double getMultiplicative()
    {
        return multiplicative;
    }

    public void applyAdditive(int additive)
    {
        additive += additive;
    }

    public void applyMultiplicative(double multiplicative)
    {
        multiplicative *= multiplicative;
    }
}
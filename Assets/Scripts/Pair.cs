public class Pair<T, K>
{
    private readonly T first;
    private readonly K second;

    public Pair(T first, K second)
    {
        this.first = first;
        this.second = second;
    }

    public T getFirst()
    {
        return first;
    }

    public K getSecond()
    {
        return second;
    }

    public bool equals(Pair<T, K> other)
    {
        return other.first.Equals(first) && other.second.Equals(second);
    }
}

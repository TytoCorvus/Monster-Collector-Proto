using System.Collections.Generic;
public class MoveLibrary
{
    private static readonly Dictionary<int/*id*/, Move> moveDictionaryById = new Dictionary<int, Move>();
    private static readonly Dictionary<string/*name*/, Move> moveDictionaryByName = new Dictionary<string, Move>();

    public static Move get(int id)
    {
        return moveDictionaryById[id];
    }

    public static Move get(string name)
    {
        return moveDictionaryByName[name];
    }
    public static void loadDictionary(int id, string name, Move move)
    {
        moveDictionaryById.Add(id, move);
        moveDictionaryByName.Add(name, move);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

public class BattleTeam
{
    private readonly List<BattleCreature> creatures;

    public BattleTeam(Team team, Owner owner, Watchers watchers)
    {
        this.creatures = team.getCreatures().Select(creature => new BattleCreature(creature, owner, watchers)).ToList();
    }

    public BattleCreature getFirst()
    {
        return creatures[0];
    }

    public BattleCreature getSecond()
    {
        return creatures[1];
    }

    public BattleCreature getCreatureInPosition(int pos)
    {
        if (!posExists(pos))
            return null;

        return creatures[pos];
    }

    public void swapPosition(int pos1, int pos2)
    {
        if (!(posExists(pos1) && posExists(pos2)))
            throw new System.Exception("Cannot swap when positions are out of bounds");

        BattleCreature first = creatures[pos1];
        BattleCreature second = creatures[pos2];
        creatures[pos1] = second;
        creatures[pos2] = first;
    }

    public bool posExists(int pos)
    {
        return pos >= 0 && pos <= creatures.Count;
    }
}

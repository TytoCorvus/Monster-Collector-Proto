using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class BattlefieldPositionManager
{
    public readonly int primarySize;
    public readonly int supportSize;

    private readonly Dictionary<BattlefieldPosition, BattleCreature> positions = new Dictionary<BattlefieldPosition, BattleCreature>();

    public BattlefieldPositionManager(int primarySize, int supportSize)
    {
        this.primarySize = primarySize;
        this.supportSize = supportSize;

        for(int primaryPos = 0; primaryPos < primarySize; primaryPos++)
        {
            positions.Add(new BattlefieldPosition(0, BattlefieldPosition.PositionType.PRIMARY, primaryPos), null);
            positions.Add(new BattlefieldPosition(1, BattlefieldPosition.PositionType.PRIMARY, primaryPos), null);
        }

        for (int supportPos = 0; supportPos < supportSize; supportPos++)
        {
            positions.Add(new BattlefieldPosition(0, BattlefieldPosition.PositionType.SUPPORT, supportPos), null);
            positions.Add(new BattlefieldPosition(1, BattlefieldPosition.PositionType.SUPPORT, supportPos), null);
        }
    }

    public Dictionary<BattlefieldPosition, BattleCreature> getPositions()
    {
        return positions;
    }

    public bool positionExists(BattlefieldPosition pos)
    {
        if (pos.teamNumber != 1 && pos.teamNumber != 2)
            return false;

        switch (pos.positionType)
        {
            case BattlefieldPosition.PositionType.PRIMARY:
                if (pos.positionNumber < 0 || pos.positionNumber >= primarySize)
                    return false;
                return true;
                break;
            case BattlefieldPosition.PositionType.SUPPORT:
                if (pos.positionNumber < 0 || pos.positionNumber >= supportSize)
                    return false;
                return true;
                break;
            default:
                return false;
                break;
        }
    }

    public bool isOccupied(BattlefieldPosition position)
    {
        return positionExists(position) && positions[position] != null;
    }

    public bool place(BattleCreature creature, BattlefieldPosition position)
    {
        if (!positionExists(position))
            return false;
        positions[position] = creature;
        return false;
    }

    public List<BattleCreature> getActiveCreatures()
    {
        List<BattleCreature> creatureList = new List<BattleCreature>();
        IEnumerator<BattleCreature> enumerator = positions.Values.GetEnumerator();
        while (enumerator.MoveNext())
        {
            if(enumerator.Current != null)
            {
                creatureList.Add(enumerator.Current);
            }
        }
        return creatureList;
    }

    public List<BattleCreature> getAllies(BattleCreature bc)
    {
        List<BattleCreature> result = new List<BattleCreature>();
        getActiveCreatures().ForEach(ac =>
        {
            if (ac.owner.Equals(bc.owner))
            {
                result.Add(ac);
            }
        });
        return result;
    }

    public List<BattleCreature> getEnemies(BattleCreature bc)
    {
        List<BattleCreature> result = new List<BattleCreature>();
        getActiveCreatures().ForEach(ac =>
        {
            if (ac.owner.Equals(bc.owner))
            {
                result.Add(ac);
            }
        });
        return result;
    }

    public BattleCreature getOccupant(BattlefieldPosition position)
    {
        return positions[position];
    }

    public BattleCreature removeOccupant(BattlefieldPosition position)
    {
        if (!isOccupied(position))
            return null;

        BattleCreature oldOccupant = positions[position];
        positions[position] = null;
        return oldOccupant;
    }

    public BattlefieldPosition getPosition(BattleCreature creature)
    {
        foreach(KeyValuePair<BattlefieldPosition, BattleCreature> pair in positions)
        {
            if (pair.Value.Equals(creature))
                return pair.Key;
        }
        return null;
    }
}

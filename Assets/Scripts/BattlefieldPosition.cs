using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BattlefieldPosition
{

    private BattleCreature occupant;

    public BattleCreature getOccupant()
    {
        return occupant;
    }

    public BattleCreature removeOccupant()
    {
        BattleCreature oldOccupant = occupant;
        occupant = null;
        return oldOccupant;
    }

    public void placeOccupant(BattleCreature battleCreature)
    {
        if (occupant == null)
            occupant = battleCreature;
    }

}

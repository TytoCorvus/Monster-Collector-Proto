using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BattlefieldPositionManager
{

    public readonly int primarySize;
    public readonly int supportSize;

    private readonly BattlefieldPosition[] player1Primary;
    private readonly BattlefieldPosition[] player1Support;
    private readonly BattlefieldPosition[] player2Primary;
    private readonly BattlefieldPosition[] player2Support;

    public BattlefieldPositionManager(int primarySize, int supportSize)
    {
        this.primarySize = primarySize;
        this.supportSize = supportSize;
        player1Primary = new BattlefieldPosition[primarySize];
        player1Support = new BattlefieldPosition[supportSize];
        player2Primary = new BattlefieldPosition[primarySize];
        player2Support = new BattlefieldPosition[supportSize];
    }



    public bool isOccupied(int player, PositionType posType, int posNum)
    {
        switch (player)
        {
            case 1:
            case 2:
            default:
                return true;
                break;
        }
    }

    public void place(BattleCreature creature, int player, PositionType posType, int posNum)
    {

    }

    public enum PositionType
    {
        PRIMARY=0,
        SUPPORT=1
    }

}

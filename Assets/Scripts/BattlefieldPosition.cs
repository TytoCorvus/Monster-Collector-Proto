using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BattlefieldPosition
{
    public readonly int teamNumber;
    public readonly PositionType positionType;
    public readonly int positionNumber;

    public BattlefieldPosition(int teamNumber, PositionType positionType, int positionNumber)
    {
        this.teamNumber = teamNumber;
        this.positionType = positionType;
        this.positionNumber = positionNumber;
    }

    public override bool Equals(object obj)
    {
        if (!(obj is BattlefieldPosition))
            return false;
        BattlefieldPosition other = (BattlefieldPosition)obj;

        return teamNumber == other.teamNumber && positionType == other.positionType && positionNumber == other.positionNumber;
    }

    public enum PositionType
    {
        PRIMARY = 0,
        SUPPORT = 1
    }
}

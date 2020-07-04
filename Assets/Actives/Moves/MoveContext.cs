using System.Collections;
using System.Collections.Generic;

public class MoveContext
{
    public readonly Move move;
    public readonly BattleCreature source;
    public readonly List<BattleCreature> allies;
    public readonly List<BattleCreature> enemies;
    public readonly List<BattleCreature> targets;

    public MoveContext(Move move, BattleCreature source, List<BattleCreature> allies, List<BattleCreature> enemies, List<BattleCreature> targets)
    {
        this.move = move;
        this.source = source;
        this.allies = allies;
        this.enemies = enemies;
        this.targets = targets;
    }

    public MovePriority getMovePriority()
    {
        return new MovePriority(move.priority, source.getCurrentStats().getStat(StatName.SPD));
    }

    public void execute()
    {

    }

    public override bool Equals(object obj)
    {
        if (!(obj is MoveContext))
            return false;
        MoveContext other = (MoveContext)obj;
        bool isEqual = true;

        isEqual &= move.Equals(other.move);
        isEqual &= source.Equals(other.source);
        if (!(allies == null && other.allies == null))
            foreach (BattleCreature bc in allies)
                isEqual &= other.allies.Contains(bc);
        if (!(enemies == null && other.enemies == null))
            foreach (BattleCreature bc in enemies)
                isEqual &= other.enemies.Contains(bc);
        if (!(targets == null && other.targets == null))
            foreach (BattleCreature bc in targets)
                isEqual &= other.targets.Contains(bc);

        return base.Equals(obj);
    }
}

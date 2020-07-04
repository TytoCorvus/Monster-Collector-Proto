using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class ChangeFocusBattleAction : BattleAction
{
    private readonly int focusChange;
    public ChangeFocusBattleAction(TargetClass targetClass, int focusChange) : base(targetClass)
    {
        this.focusChange = focusChange;
    }

    public override BattleActionResult execute(BattleCreature source, List<BattleCreature> targets, double amp, double hitChanceMultiplier, double alteredChanceForSecondary)
    {
        bool anyInteractable = false;
        foreach (BattleCreature bc in targets)
        {
            anyInteractable |= bc.isInteractable();
            if (bc.isInteractable())
                bc.changeFocus(focusChange);
        }

        return new BattleActionResult(anyInteractable, anyInteractable);
    }

}

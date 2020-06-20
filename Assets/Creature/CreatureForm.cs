using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreatureForm
{
    public readonly List<CreatureType> creatureTypes;
    public readonly List<Pair<StatName, StatModifier>> statMods;
    public readonly Ability formAbility;
    public readonly BattleAction revealAction;
    public readonly Move signature;

    public CreatureForm(List<CreatureType> creatureTypes, Ability formAbility, BattleAction revealAction)
    {
        //Only ever used for base form
        this.creatureTypes = creatureTypes;
        this.statMods = new List<Pair<StatName, StatModifier>>();
        this.formAbility = formAbility;
        this.revealAction = revealAction;
        this.signature = null;
    }
    public CreatureForm(List<CreatureType> creatureTypes, List<Pair<StatName, StatModifier>> statMods, Ability formAbility, BattleAction revealAction, Move signature)
    {
        //Used for forms requiring a reveal
        this.creatureTypes = creatureTypes;
        this.statMods = statMods;
        this.formAbility = formAbility;
        this.revealAction = revealAction;
        this.signature = signature;
    }

}


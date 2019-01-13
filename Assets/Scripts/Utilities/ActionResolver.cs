using System;
using System.Collections.Generic;

static class ActionResolver 
{
    public static void resolve(List<UnitAction> actions, UnitModel target)
    {
        foreach(var action in actions)
        {
            applyEffect(action, target);
        }
    }

    private static void applyEffect(UnitAction action, UnitModel target) 
    {
        switch(action.type)
        {
            case UnitAction.ActionType.PHYSICAL_ATTACK: 
                onPhysicalAttack(action, target);
                break;
            case UnitAction.ActionType.MAGIC_ATTACK:
                onMagicAttack(action, target);
                break;
            case UnitAction.ActionType.STAT_MODIFIER:
                onStatModifier(action, target);
                break;
            default:
                break;
        }
    }

    private static void onPhysicalAttack(UnitAction action, UnitModel target)
    {
        //TODO need to figure out how we want def to actually affect damage.
        int damageAmount = action.amount - target.def;
        target.applyDamage(damageAmount);
    }

    private static void onMagicAttack(UnitAction action, UnitModel target)
    {
        int damageAmount = action.amount - target.def;
        target.applyDamage(damageAmount);
    }

    private static void onStatModifier(UnitAction action, UnitModel target)
    {
        //TODO
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeAction : CombatActionBase
{
    public FleeAction()
    {
        type = targetType.NONE;
        name = "Flee";
        description = "Run away from the fight.";
        element = new Elements(Elements.elementTypes.NONE);
    }

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}

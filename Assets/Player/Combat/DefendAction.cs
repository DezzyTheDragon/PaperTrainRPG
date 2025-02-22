using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendAction : CombatActionBase
{
    public DefendAction()
    {
        type = targetType.NONE;
        name = "Defend";
        description = "Reduce incomming damage";
        element = new Elements(Elements.elementTypes.NONE);
    }

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}

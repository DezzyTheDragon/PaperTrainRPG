using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHeal : CombatActionBase
{
    public TestHeal()
    {
        type = targetType.ALLY;
        name = "Test Heal";
        description = "A test heal";
    }

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}

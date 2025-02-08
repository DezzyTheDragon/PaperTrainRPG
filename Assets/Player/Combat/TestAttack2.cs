using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack2 : CombatActionBase
{
    public TestAttack2()
    {
        type = targetType.AOE_FOE;
        name = "Test 2";
        description = "A different test attack.";
    }

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}

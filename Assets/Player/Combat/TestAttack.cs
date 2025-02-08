using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAttack : CombatActionBase
{
    public TestAttack()
    {
        type = targetType.FOE;
        name = "Test";
        description = "Test Attack.";
    }

    public override void ExecuteAction()
    {
        base.ExecuteAction();
    }
}

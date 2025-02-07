using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum targetType { FOE, AOE_FOE, ALLY, AOE_ALLY, NONE }

public class CombatActionBase
{
    protected targetType targetType;
    protected string name;
    protected string description;

    public static int GetAttackID() { return -1; }

    public targetType GetTargetType()
    {
        return targetType;
    }
    public string GetName()
    {
        return name;
    }
    public string GetDescription()
    {
        return description;
    }

    public void ExecuteAction()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum targetType { FOE, AOE_FOE, ALLY, AOE_ALLY, NONE }

public class CombatActionBase
{
    protected targetType type;
    protected string name;
    protected string description;

    public targetType GetTargetType()
    {
        return type;
    }
    public string GetName()
    {
        return name;
    }
    public string GetDescription()
    {
        return description;
    }

    public virtual void ExecuteAction()
    {
        
    }
}

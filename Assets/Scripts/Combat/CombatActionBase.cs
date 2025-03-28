using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum targetType { NONE, FOE, AOE_FOE, ALLY, AOE_ALLY }

public class CombatActionBase
{
    protected targetType type;
    protected string name;
    protected string description;
    protected Elements element;

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

    public Elements GetElement()
    {
        return element;
    }

    public virtual void ExecuteAction(Animator animator)
    {
        
    }
}

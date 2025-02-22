using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elements
{
    public enum elementTypes { NONE, FIRE, WATER, EARTH, AIR, EATHER };

    // AIR beats EARTH
    // EARTH beats WATER
    // WATER beats FIRE
    // FIRE beats AIR
    // EATHER beats all
    // NONE beats none
    private Dictionary<elementTypes, elementTypes> typeEffective = new Dictionary<elementTypes, elementTypes>()
    {
        { elementTypes.AIR, elementTypes.EARTH },
        { elementTypes.EARTH, elementTypes.WATER },
        { elementTypes.WATER, elementTypes.FIRE },
        { elementTypes.FIRE, elementTypes.AIR }
    };

    private elementTypes type;

    public Elements(elementTypes type)
    {
        this.type = type;
    }

    public elementTypes GetElementType()
    {
        return type;
    }

    public bool IsStrongAgainst(Elements other)
    {
        elementTypes otherType = other.GetElementType();

        if (typeEffective[type] == otherType || type == elementTypes.EATHER)
        {
            return true;
        }

        return false;
    }

    public bool IsWeakAgainst(Elements other)
    {
        elementTypes otherType = other.GetElementType();

        if (typeEffective[otherType] == type || type == elementTypes.NONE)
        {
            return true;
        }

        return false;
    }
}

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
    private static Dictionary<elementTypes, elementTypes> typeEffective = new Dictionary<elementTypes, elementTypes>()
    {
        { elementTypes.AIR, elementTypes.EARTH },
        { elementTypes.EARTH, elementTypes.WATER },
        { elementTypes.WATER, elementTypes.FIRE },
        { elementTypes.FIRE, elementTypes.AIR }
    };

    //private elementTypes type;

    /*public Elements(elementTypes type)
    {
        this.type = type;
    }*/

    /*public elementTypes GetElementType()
    {
        return type;
    }*/

    public static bool IsStrongAgainst(elementTypes us, elementTypes other)
    {
        //elementTypes otherType = other.GetElementType();
        if(us != elementTypes.NONE)
        {
            if (typeEffective[us] == other)
            {
                return true;
            }
        }
        else if (us == elementTypes.EATHER)
        {
            return true;
        }

        return false;
    }

    public static bool IsWeakAgainst(elementTypes us, elementTypes other)
    {
        //elementTypes otherType = other.GetElementType();

        try
        {
            if (typeEffective[other] == us || us == elementTypes.NONE)
            {
                return true;
            }
        }
        catch(System.Exception e)
        {
            Debug.LogError("ERROR: There was an error referencing element weakness! Types: " + other.ToString() + " and " + us.ToString());
            Debug.LogError(e);
        }

        return false;
    }
}

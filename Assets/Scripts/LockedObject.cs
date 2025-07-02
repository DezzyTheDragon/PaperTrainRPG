using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is for objects that are locked and need some
//  sort of key or item in order to unlock or use the
//  item.

//If key item is not in inventory
//  Logic A
//else
//  Remove key item if needed
//  Logic B

public class LockedObject : ObjectBase
{
    [Header("Locked Config")]
    public bool consumeKey = false;
    //public itemObjectStructThing? keyItem;

    public override void Interact()
    {
        //TODO: Implement inventory check logic
        //if(no item)
        //  LockedLogic()
        //else
        //  maybe remove
        //  UnlockedLogic()

        LockedLogic();

    }

    public void LockedLogic()
    {
        Debug.Log("It is locked!");
    }

    public void UnlockedLogic()
    {

    }

}

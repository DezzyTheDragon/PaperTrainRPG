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
    protected GameObject player;
    
    [Header("Locked Config")]
    public bool consumeKey = false;
    public KeyItems key;

    public override void Interact(GameObject interactor)
    {
        player = interactor;
        PlayerInventory playerInventory = interactor.GetComponent<PlayerWorld>().inventory;

        if (playerInventory.CheckKeyItem(key))
        {
            playerInventory.RemoveKeyItem(key);
            UnlockedLogic();
        }
        else
        {
            LockedLogic();
        }
    }

    public virtual void LockedLogic()
    {
        Debug.Log("It is locked!");
    }

    public virtual void UnlockedLogic()
    {
        Debug.Log("It is unlocked!");
    }

}

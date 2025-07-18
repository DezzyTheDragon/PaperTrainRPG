using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private static PlayerInventory instance;

    //Inventory item types
    //- consumable battle only items
    //- consumable healing items
    //- key items

    private List<Items> genericItems = new List<Items>();
    private List<KeyItems> keyItems = new List<KeyItems>();

    private PlayerInventory()
    {
        //TODO: Load player inventory from save file
    }

    public static PlayerInventory GetInstance()
    {
        if(instance == null)
        {
            instance = new PlayerInventory();
        }

        return instance;
    }

    public void AddKeyItem(KeyItems item)
    {
        keyItems.Add(item);
    }

    public bool CheckKeyItem(KeyItems item)
    {
        return keyItems.Contains(item);
    }

    public bool RemoveKeyItem(KeyItems item) 
    { 
        return keyItems.Remove(item); 
    }
}

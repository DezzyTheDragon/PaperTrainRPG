using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTag { GEN, KEYS }

[CreateAssetMenu(fileName = "Item", menuName = "Items/GenericItem", order = 1)]
public class Items : ScriptableObject
{
    public int id;
    public ItemTag tag;
    public string nameKey;
    public string resourceString;
    public Sprite texture;
}

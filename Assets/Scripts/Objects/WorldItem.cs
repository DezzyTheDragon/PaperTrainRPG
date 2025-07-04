using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour, Interactable
{
    [SerializeField]
    private Items item;

    public SpriteRenderer sprite;

    private void Awake()
    {
        sprite.sprite = item.texture;
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }

    public bool isInteractable()
    {
        throw new System.NotImplementedException();
    }

}

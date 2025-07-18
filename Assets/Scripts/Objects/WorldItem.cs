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
        //TODO: Story flag and remove if already colected
    }

    public void Interact(GameObject interactor)
    {
        PlayerWorld temp = interactor.GetComponent<PlayerWorld>();
        if(item.tag == ItemTag.KEYS)
        {
            temp.inventory.AddKeyItem((KeyItems)item);
        }

        //TODO: Story flag to indicate this particular item has been colected

        temp.ForceInteractionClose();

        Destroy(this.gameObject);
    }

    public bool isInteractable()
    {
        return true;
    }

}

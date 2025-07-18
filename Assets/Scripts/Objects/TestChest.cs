using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestChest : LockedObject
{
    private bool isLocked = true;

    public override void LockedLogic()
    {
        base.LockedLogic();
    }

    public override void UnlockedLogic()
    {
        base.UnlockedLogic();
        player.GetComponent<PlayerWorld>().ForceInteractionClose();
        isLocked = false;
    }

    public override bool isInteractable()
    {
        return isLocked;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private ICombat targetInterface;
    private GameObject targetObject;

    public void initButton(GameObject target)
    {
        targetObject = target;
        targetInterface = target.GetComponent<ICombat>();
    }

    public GameObject GetTarget()
    {
        return targetObject;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        targetInterface.Unhighlight();
    }

    public void OnSelect(BaseEventData eventData)
    {
        targetInterface.Highlight();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BookMarkers : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private UnityEvent selectedBehavior;

    public void OnDeselect(BaseEventData eventData)
    {
        //Debug.Log(gameObject.name + " Unselected");
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(gameObject.name + " Selected");
        selectedBehavior.Invoke();
    }
}

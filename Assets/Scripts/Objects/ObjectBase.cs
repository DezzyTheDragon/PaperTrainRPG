using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour, Interactable
{
    public virtual void Interact(GameObject interactor)
    {
        Debug.Log("Interacted");
    }

    public virtual bool isInteractable()
    {
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat
{
    public string GetName();
    public void Highlight();
    public void Unhighlight();
    public void DoTurn();
    //public void SetStatus(some paramater to indicate the status);
}

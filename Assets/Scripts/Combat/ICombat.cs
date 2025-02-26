using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat
{
    //Get entity position (not zero indexed)
    public int GetPosition();
    public void SetPosition(int pos);
    public string GetName();
    public void Highlight();
    public void Unhighlight();
    public void DoTurn(ICombat target, CombatAction action);
    //public void SetStatus(some paramater to indicate the status);

    public void Damage(int baseDamage, Elements.elementTypes attackElement);

    public bool IsFinished();
}

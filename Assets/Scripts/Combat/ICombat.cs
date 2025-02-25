using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICombat
{
    public int GetPosition();
    public string GetName();
    public void Highlight();
    public void Unhighlight();
    public void DoTurn(ICombat target, CombatAction action);
    //public void SetStatus(some paramater to indicate the status);

    public void Damage(int baseDamage, Elements attackElement);

    public bool IsFinished();
}

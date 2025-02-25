using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatAction", menuName = "Combat Actions", order = 1)]
public class CombatAction : ScriptableObject
{
    public targetType type;
    public int baseDamage;
    public string langKey;
    public Elements.elementTypes element;
    public GameObject QTE_UI;
}

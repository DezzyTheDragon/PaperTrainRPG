using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatBase : MonoBehaviour, ICombat
{
    [SerializeField] private GameObject indicator;

    protected string enemyName = "EnemyBase";
    protected int maxHP = 10;
    protected int currentHP;
    protected Elements element;

    public void DoTurn(ICombat target, CombatAction action)
    {
        throw new System.NotImplementedException();
    }

    public int GetPosition()
    {
        return 0;
    }

    public string GetName()
    {
        return enemyName;
    }

    public void Highlight()
    {
        indicator.SetActive(true);
    }

    public void Unhighlight()
    {
        indicator.SetActive(false);
    }

    public void Damage(int baseDamage, Elements attackElement)
    {
        int damage = baseDamage;
        if (element.IsStrongAgainst(attackElement))
        {
            damage--;
        }
        else if (element.IsWeakAgainst(attackElement))
        {
            damage++;
        }

        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }

    public bool IsFinished()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatBase : MonoBehaviour, ICombat
{
    private int position;
    [SerializeField] private GameObject indicator;
    [SerializeField] protected int defense = 0;
    [SerializeField] protected int maxHP = 10;
    protected int currentHP;
    protected string enemyName = "EnemyBase";
    protected Elements.elementTypes element = Elements.elementTypes.NONE;

    private CombatSystem cbs;

    public void DoTurn(ICombat target, CombatAction action)
    {
        throw new System.NotImplementedException();
    }

    public void SetPosition(int pos)
    {
        position = pos;
    }

    public int GetPosition()
    {
        return position;
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

    public void Damage(int baseDamage, Elements.elementTypes attackElement)
    {
        int damage = baseDamage - defense;
        if (Elements.IsStrongAgainst(element, attackElement))
        {
            damage--;
        }
        else if (Elements.IsWeakAgainst(element, attackElement))
        {
            damage++;
        }

        if(damage < 0)
        {
            damage = 0;
        }

        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
            IsDead();
        }
        Debug.Log(this.gameObject.name + " HP: " + currentHP + "/" + maxHP);
    }

    private void IsDead() 
    {
        //TODO: Add animation

        //TODO: Add function in combat system to notify the enemy has died
        cbs.NotifyIsDead(this.gameObject);
    }

    public bool IsFinished()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        cbs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CombatSystem>();
        if (cbs == null)
        {
            throw new System.Exception(this.gameObject.name + " failed to find GameManager object with CombatSystem component.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}

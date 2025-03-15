using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCombatBase : MonoBehaviour, ICombat
{
    private int position;
    [SerializeField] private GameObject indicator;
    [SerializeField] protected int defense = 0;
    [SerializeField] protected int maxHP = 10;
    [SerializeField] protected Elements.elementTypes element = Elements.elementTypes.NONE;
    [SerializeField] protected string enemyName = "EnemyBase";

    [SerializeField] private GameObject root;

    protected int currentHP;

    private CombatSystem cbs;
    //private List<GameObject> spawnReference;

    private Animator animator;

    private ICombat playerRef;

    private void OnEnable()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        cbs = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CombatSystem>();
        if (cbs == null)
        {
            throw new System.Exception(this.gameObject.name + " failed to find GameManager object with CombatSystem component.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoTurn(ICombat target, CombatAction action)
    {
        playerRef = target;
        animator.SetBool("attack", true);
    }

    public void SetPosition(int pos)
    {
        position = pos;
        animator.SetInteger("position", pos);
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

    //Called by animation to signal the attack is in block range
    public void SignalBlock(int enabled)
    {
        bool canBlock = enabled == 0 ? false : true;
        Debug.Log(gameObject.name + "'s attack can be blocked: " + canBlock.ToString());
    }

    //Called by animation attack node
    public void DoDamage()
    {
        SignalBlock(0);
        Debug.Log(gameObject.name + " attacked");
    }

    //Called right before going back to idle animation node
    public void AnimationLoopEnd()
    {
        //animator.SetInteger("position", 0);
        animator.SetBool("attack", false);
        Debug.Log(gameObject.name + " ended attack cycle");
        cbs.OnTurnEnd();
    }
    
}

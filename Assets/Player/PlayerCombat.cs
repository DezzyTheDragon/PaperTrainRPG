using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour, ICombat
{
    PlayerStats stats = PlayerStats.GetInstatnce();

    [SerializeField] private GameObject indicator;
    [SerializeField] private Canvas canvas;

    private Animator animator;

    CombatAction combatAction;
    ICombat target;

    // Start is called before the first frame update
    void Start()
    {
        indicator.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoTurn(ICombat target, CombatAction action)
    {
        this.target = target;
        combatAction = action;

        Debug.Log("Doing player turn");

        //combatAction.ExecuteAction(animator);
        GameObject ui = Instantiate(action.QTE_UI, canvas.gameObject.transform);
        ui.GetComponent<TestAttack1UI>().SetPlayerRef(this);
        //Later pass player ref so QTE can inform player QTE is over
    }

    public void QTEFinished(bool status) 
    {
        animator.SetInteger("position", target.GetPosition());
        animator.SetInteger("attackID", combatAction.animationID);
        //The animation starts playing
    }

    public void SetPosition(int pos)
    {

    }

    public int GetPosition()
    {
        return 1;
    }

    public string GetName()
    {
        throw new System.NotImplementedException();
    }

    public void Highlight()
    {
        indicator.SetActive(true);
    }

    public void Unhighlight()
    {
        indicator.SetActive(false);
    }

    public bool IsFinished()
    {
        return false;
    }

    public void Damage(int baseDamage, Elements.elementTypes attackElement)
    {
        throw new System.NotImplementedException();
    }

    //This function is called from an animation event
    public void DoDamage()
    {
        animator.SetInteger("position", 0);
        animator.SetInteger("attackID", 0);
        target.Damage(combatAction.baseDamage, combatAction.element);
        Debug.Log("Damage the enemy");
    }
}

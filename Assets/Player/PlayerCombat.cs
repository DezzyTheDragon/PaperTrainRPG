using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombat
{
    PlayerStats stats = PlayerStats.GetInstatnce();

    [SerializeField] private GameObject indicator;

    private Animator animator;

    CombatActionBase combatAction;
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

    public void DoTurn(ICombat target, CombatActionBase action)
    {
        this.target = target;
        combatAction = action;
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

    public void Damage(int baseDamage, Elements attackElement)
    {
        throw new System.NotImplementedException();
    }

    public void DoDamage()
    {
        Debug.Log("Damage the enemy");
    }
}

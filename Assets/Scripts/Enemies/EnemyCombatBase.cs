using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatBase : MonoBehaviour, ICombat
{
    [SerializeField] private GameObject indicator;

    protected string enemyName = "EnemyBase";
    protected int maxHP = 10;
    protected int currentHP;

    public void DoTurn()
    {
        throw new System.NotImplementedException();
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

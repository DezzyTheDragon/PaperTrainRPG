using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatBase : MonoBehaviour
{
    protected string enemyName = "EnemyBase";
    protected int maxHP = 10;
    protected int currentHP;

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

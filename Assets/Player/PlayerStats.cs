using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for managing the player stats, info, and possibly inventory

public class PlayerStats
{
    private static PlayerStats instance;

    private int maxHP = 10;
    private int currentHP;
    private int maxMP = 10;
    private int currentMP;

    //Combat action info
    // - List of Attack Actions
    // - List of Non-Attack Actions

    private List<CombatActionBase> actionList = new List<CombatActionBase> { new DefendAction(), new FleeAction() };

    //DEBUG
    private List<CombatActionBase> combatAction = new List<CombatActionBase> { new TestAttack(), new TestAttack2(), new TestHeal() };

    public static PlayerStats GetInstatnce() 
    {
        if (instance == null)
        {
            instance = new PlayerStats();
        }
        return instance; 
    }

    private PlayerStats()
    {
        //TODO: read current values from the save system
        currentHP = maxHP;
        currentMP = maxMP;
    }

    public int GetHP()
    {
        return currentHP;
    }

    public void RemoveHP(int dmg)
    {
        currentHP -= dmg;
        if(currentHP < 0) currentHP = 0;
    }

    public void AddHP(int heal)
    {
        currentHP += heal;
        if(currentHP > maxHP) currentHP = maxHP;
    }

    public int GetMP()
    {
        return currentMP;
    }

    public void RemoveMP(int sub)
    {
        currentMP -= sub;
        if (currentMP < 0) currentMP = 0;
    }

    public void AddMP(int add)
    {
        currentMP += add;
        if (currentMP > maxMP) currentMP = maxMP;
    }

    public List<CombatActionBase> GetAttackActions()
    {
        return combatAction;
    }

    public List<CombatActionBase> GetActions()
    {
        return actionList;
    }
}

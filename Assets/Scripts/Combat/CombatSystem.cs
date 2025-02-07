using System.Collections;
using System.Collections.Generic;
using UnityEngine;
enum combatState { START, PLAYERTURN, ENEMYTURN, WON, LOST};

public class CombatSystem : MonoBehaviour
{
    //private combatState currentState = combatState.START;
    //private int enemyIndex = 0;
    //private int enemyCount;

    private List<GameObject> enemyList = new List<GameObject>();

    [Header("Config")]
    public List<GameObject> enemySpawns = new List<GameObject>();
    [SerializeField] private CombatUI combatUI;

    [Header("DEBUG")]
    public List<GameObject> enemyRoster = new List<GameObject>();

    private void Start()
    {

        StartCoroutine(InitCombat());
    }

    private IEnumerator InitCombat() 
    {
        int i = 0;
        foreach (GameObject enemy in enemyRoster)
        {
            enemyList.Add(Instantiate(enemy, enemySpawns[i].transform.position, enemySpawns[i].transform.rotation));
            i++;
        }
        combatUI.ConfigureEnemyPanel(enemyList);
        return null;
    }
    

    //Evaluate the state of battle
    // check if enemies are alive/dead
    // check if player is alive/dead
    public void OnTurnEnd()
    {
        //Is player alive?

        //Did enemy die?
    }
}

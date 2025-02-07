using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:
//  X Create interface for combat
//    X Get name - Returns entity name
//    X Highlight - Highlights the entity, arrow points to the enemy you want to hit or friend you want to heal
//    X Do Turn - Execute the action for that entities turn
//    * Set Status - this would be for poison, slow healing, confused, etc
//  X Create CombatAction base class
//    X target enum (FOE, ALLY, AOE_FOE, AOE_ALLY, NONE)
//    X Get name
//    X Get description
//    X Get target type
//    X Execute Action
//  - Construct battle field
//    * Place players
//    * Place enemies
//    * Generate player UI
//      - Instantiate player actions
//      - Instantiate enemy button lists
//    * Re-theme stage (not priority)
//  - Player Turn
//    * Button saves action
//    * Button selects target
//    * Run action
//  - Enemy Turn
//    * Run action


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
        //StartCoroutine(InitCombat());
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

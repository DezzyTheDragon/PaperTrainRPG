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
//    X Place players
//    X Place enemies
//    * Generate player UI
//      - Instantiate player actions
//      - Instantiate enemy button lists
//    * Re-theme stage (not priority)
//  - Player Turn
//    * Button saves action
//    * Button selects target
//    * Run action
//    * Action QT
//  - Enemy Turn
//    * Run action


enum combatState { START, PLAYERTURN, ENEMYTURN, WON, LOST};

public class CombatSystem : MonoBehaviour
{
    //private combatState currentState = combatState.START;
    //private int enemyIndex = 0;
    //private int enemyCount;

    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject player;

    [Header("Config")]
    public GameObject playerPrefab;
    public List<GameObject> enemySpawns = new List<GameObject>();
    public GameObject playerSpawn;
    [SerializeField] private CombatUI combatUI;

    [Header("DEBUG")]
    public List<GameObject> enemyRoster = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(InitCombat());
    }

    private IEnumerator InitCombat() 
    {
        // Create and place player objects
        player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);
        //TESTING ===========
        //combatUI.ConfigureAttackPanel(PlayerStats.GetInstatnce().GetAttackActions());
        combatUI.initAttackPage(PlayerStats.GetInstatnce().GetAttackActions());
        //===================

        // NOTE: If a companion is added they would be created here as well
        
        // Create and place enemies
        int i = 0;
        foreach (GameObject enemy in enemyRoster)
        {
            enemyList.Add(Instantiate(enemy, enemySpawns[i].transform.position, Quaternion.identity));
            i++;
        }
        //combatUI.ConfigureEnemyPanel(enemyList);
        
        yield return new WaitForEndOfFrame();
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

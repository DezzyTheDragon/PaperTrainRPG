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
//  X Construct battle field
//    X Place players
//    X Place enemies
//    X Generate player UI
//      X Instantiate player actions
//      X Instantiate enemy button lists
//    * Re-theme stage (not priority)
//  - Player Turn
//    * Button saves action
//    * Button selects target
//    * Run action
//    * Action QT
//  - Enemy Turn
//    * Run action


enum combatState { START, PLAYERTURN, ENEMYTURN, WON, LOST};

struct battleConfig 
{
    bool canFlee;
    List<GameObject> enemyList;
};

public class CombatSystem : MonoBehaviour
{
    //private combatState currentState = combatState.START;
    //private int enemyIndex = 0;
    //private int enemyCount;

    private CombatActionBase playerAction;

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
        combatUI.initAttackPage(PlayerStats.GetInstatnce().GetAttackActions());
        combatUI.initActionPage(PlayerStats.GetInstatnce().GetActions());
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
    
    public void SetCombatAction(CombatActionBase action)
    {
        playerAction = action;
        if (playerAction.GetTargetType() == targetType.NONE)
        {
            //Advance combat state
        }
    }

    public void SetTarget(GameObject enemy) 
    {
        //Advance combat state after target selection
    }

    public void SetAllTargets() 
    {
        //Advance combat state after selection
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

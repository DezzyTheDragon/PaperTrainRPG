using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

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


//enum combatState { START, PLAYERTURN, ENEMYTURN, WON, LOST};
enum combatState { BUILD, ACTION_SELECT, TARGET_SELECT, ATTACK_PHASE };

struct battleConfig 
{
    bool canFlee;
    List<GameObject> enemyList;
};

public class CombatSystem : MonoBehaviour
{
    private combatState currentState;
    //private int enemyIndex = 0;
    //private int enemyCount;

    private CombatAction playerAction;

    private List<GameObject> enemyList = new List<GameObject>();
    private GameObject player;

    [Header("Config")]
    public GameObject playerPrefab;
    public List<GameObject> enemySpawns = new List<GameObject>();
    public GameObject playerSpawn;
    [SerializeField] private CombatUI combatUI;

    [Header("DEBUG")]
    public List<GameObject> enemyRoster = new List<GameObject>();
    public List<CombatAction> miscActions = new List<CombatAction>();
    public List<CombatAction> attackActions = new List<CombatAction>();

    private void Start()
    {
        StartCoroutine(InitCombat());
        EventSystem.current.GetComponent<InputSystemUIInputModule>().cancel.action.performed += OnCancel;
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (currentState == combatState.ACTION_SELECT)
        {
            combatUI.CancelPage();
        }
        else if(currentState == combatState.TARGET_SELECT)
        {
            currentState = combatState.ACTION_SELECT;
            combatUI.ShowBook();
        }
    }

    private IEnumerator InitCombat() 
    {
        currentState = combatState.BUILD;
        // Create and place player objects
        player = Instantiate(playerPrefab, playerSpawn.transform.position, Quaternion.identity);

        //TESTING ===========
        //combatUI.initAttackPage(PlayerStats.GetInstatnce().GetAttackActions());
        //combatUI.initActionPage(PlayerStats.GetInstatnce().GetActions());

        combatUI.initAttackPage(attackActions);
        combatUI.initActionPage(miscActions);
        //===================

        // NOTE: If a companion is added they would be created here as well
        
        // Create and place enemies
        int i = 0;
        foreach (GameObject enemy in enemyRoster)
        {
            enemyList.Add(Instantiate(enemy, enemySpawns[i].transform.position, Quaternion.identity));
            i++;
        }

        combatUI.initEnemySelection(enemyList);
        
        yield return new WaitForEndOfFrame();

        currentState = combatState.ACTION_SELECT;
    }
    
    public void SetCombatAction(CombatAction action)
    {
        playerAction = action;
        combatUI.HideBook();
        currentState = combatState.TARGET_SELECT;
        if(action.type == targetType.NONE)
        {
            //Advance battle state
        }
        else if(action.type == targetType.AOE_FOE || action.type == targetType.AOE_ALLY)
        {
            /*
            //Request AEO target
            if(action.GetTargetType() == targetType.AOE_FOE)
            {
                foreach(GameObject enemy in enemyList)
                {
                    enemy.GetComponent<ICombat>().Highlight();
                }
            }
            else
            {

            }
            */
        }
        else if(action.type == targetType.FOE || action.type == targetType.ALLY)
        {
            //Request single target
            combatUI.RequestSingleTarget();
        }
    }

    /*public void requestSingleTarget()
    {
        if (playerAction.GetTargetType() == targetType.ALLY)
        {
            //highlight ally players
        }
        else //targetType == FOE
        {

        }
    }*/

    public void SetTarget(GameObject enemy) 
    {
        currentState = combatState.ATTACK_PHASE;

        player.GetComponent<ICombat>().DoTurn(enemy.GetComponent<ICombat>(), playerAction);

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

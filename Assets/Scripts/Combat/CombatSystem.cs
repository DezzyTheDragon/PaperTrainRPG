using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

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
    private bool isPlayerTurn;
    //private int enemyIndex = 0;
    //private int enemyCount;

    private CombatAction playerAction;

    private GameObject player;  //GameObject that represents the playable character
    private List<GameObject> enemyList = new List<GameObject>();    //The list that contains the GameObjects for the enemies in the scene
    private List<GameObject> deadEnemyQueue = new List<GameObject>(); //List of enemies to get rid of at the end of the turn action


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
            GameObject enemyObj = Instantiate(enemy, enemySpawns[i].transform.position, Quaternion.identity);
            ICombat enemyCombat = enemyObj.GetComponent<ICombat>();
            enemyCombat.SetPosition(i + 1);

            enemyList.Add(enemyObj);
            i++;
        }

        combatUI.initEnemySelection(enemyList);
        
        yield return new WaitForEndOfFrame();

        currentState = combatState.ACTION_SELECT;
        isPlayerTurn = true;
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
            
        }
        else if(action.type == targetType.FOE || action.type == targetType.ALLY)
        {
            //Request single target
            combatUI.RequestSingleTarget();
        }
    }

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

    public void EnemyTurn()
    {
        //TESTING
        OnTurnEnd();
    }

    //Evaluate the state of battle
    // check if enemies are alive/dead
    // check if player is alive/dead
    public void OnTurnEnd()
    {
        //Is player alive?

        //Did enemy die?
        bool rosterChange = false;
        foreach(GameObject dead in deadEnemyQueue)
        {
            //Remove enemy from field
            enemyList.Remove(dead);

            Destroy(dead);

            rosterChange = true;
        }

        if (rosterChange)
        {
            combatUI.RecalculateEnemySelection(enemyList);
        }

        if (isPlayerTurn)
        {
            isPlayerTurn = false;
            EnemyTurn();
        }
        else
        {
            currentState = combatState.ACTION_SELECT;
            isPlayerTurn = true;
            combatUI.ShowBook();
        }
    }

    public void NotifyIsDead(GameObject deadEnemy)
    {
        deadEnemyQueue.Add(deadEnemy);
    }
}

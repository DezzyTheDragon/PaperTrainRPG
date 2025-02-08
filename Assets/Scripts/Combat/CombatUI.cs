using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//NOTE: This will be changed at the UI changes

public class CombatUI : MonoBehaviour
{
    [SerializeField] private GameObject attackPanel;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private GameObject actionPanel;
    [SerializeField] private GameObject targetPanel;
    [SerializeField] private GameObject buttonPrefab;

    private List<GameObject> enemyButtons = new List<GameObject>();

    private GameObject activePanel;

    public void OnAttackPressed() 
    {
        attackPanel.SetActive(true);
        activePanel = attackPanel;
    }
    public void OnItemsPressed() 
    {
        itemPanel.SetActive(true);
        activePanel = itemPanel;
    }
    public void OnActionPressed() 
    {
        actionPanel.SetActive(true);
        activePanel = actionPanel;
    }
    public void PanelReturn()
    {
        activePanel.SetActive(false);
        activePanel = null;
    }

    public void SwapPanel()
    {
        activePanel.SetActive(false);
        targetPanel.SetActive(true);
        activePanel = targetPanel;
    }

    public void ConfigureAttackPanel(List<CombatActionBase> attackActions) 
    {
        int i = 0;
        foreach (CombatActionBase attack in attackActions)
        {
            //GameObject tempButton = Instantiate(buttonPrefab, new Vector3(0, 35 * i, 0), Quaternion.identity, attackPanel.gameObject.transform);
            //tempButton.GetComponentInChildren<TextMesh>().text = attack.GetName();
            //tempButton.GetComponent<Button>().onClick += TODO: Add function select here
        }
    }

    public void ConfigureEnemyPanel(List<GameObject>enemyRoster)
    {
        int i = 0;
        foreach (GameObject enemy in enemyRoster)
        {
            GameObject tempButton = Instantiate(buttonPrefab, new Vector3(0, 35 * i, 0), Quaternion.identity, targetPanel.gameObject.transform);
            enemyButtons.Add(tempButton);

            tempButton.GetComponentInChildren<TextMesh>().text = enemy.name;
            //tempButton.GetComponent<Button>().onClick += TODO: Add function select here

            i++;
        }
    }
}

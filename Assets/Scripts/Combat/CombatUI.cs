using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CombatUI : MonoBehaviour
{
    private CombatSystem combatSystem;

    //UI ELEMENT REFERENCE
    [SerializeField] private Button attackButton;
    [SerializeField] private Button itemButton;
    [SerializeField] private Button actionButton;
    [SerializeField] private GameObject magicPageImage;
    [SerializeField] private GameObject itemPageImage;
    [SerializeField] private GameObject actionPageImage;
    [SerializeField] private GameObject pageTitle;
    private TMP_Text pageTitleText;
    [SerializeField] private GameObject leftPage;
    [SerializeField] private GameObject rightPage;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject scrollContent;
    private RectTransform scrollRectTransform;
    [SerializeField] private GameObject attackContent;
    [SerializeField] private GameObject itemContent;
    [SerializeField] private GameObject actionContent;

    private List<Button> attackButtonList = new List<Button>();
    private List<Button> itemButtonList = new List<Button>();
    private List<Button> actionButtonList = new List<Button>();

    private void Start()
    {
        combatSystem = GetComponentInParent<CombatSystem>();
        pageTitleText = pageTitle.GetComponent<TMP_Text>();
        scrollRectTransform = scrollContent.GetComponent<RectTransform>();
        attackButton.Select();
    }

    private void initCombatBook()
    {
        
    }

    public void initAttackPage(List<CombatActionBase> attacks)
    {
        int i = 0;
        foreach(CombatActionBase attack in attacks)
        {
            Vector3 pos = new Vector3(
                attackContent.transform.position.x, 
                attackContent.transform.position.y + (i * -30), 
                attackContent.transform.position.z);
            GameObject tempButtonObj = Instantiate(buttonPrefab, pos, Quaternion.identity, attackContent.transform);
            Button tempButton = tempButtonObj.GetComponent<Button>();
            attackButtonList.Add(tempButton);
            ConfigCombatButton temp = tempButtonObj.GetComponent<ConfigCombatButton>();
            tempButtonObj.name = attack.GetName() + " Button";
            
            temp.setData(attack.GetName(), "", attack);
            tempButton.onClick.AddListener(delegate { combatSystem.SetCombatAction(attack); });

            if(i > 0)
            {
                Navigation nav = attackButtonList[i - 1].navigation;
                nav.selectOnDown = tempButton;
                attackButtonList[i - 1].navigation = nav;

                nav = tempButton.navigation;
                nav.selectOnUp = attackButtonList[i - 1];
                tempButton.navigation = nav;
            }

            i++;
        }

        scrollRectTransform.sizeDelta = new Vector2(0, 30 * i);
    }

    private void initItemPage()
    {

    }

    public void initActionPage(List<CombatActionBase> actions)
    {
        int i = 0;
        foreach(CombatActionBase action in actions)
        {
            Vector3 pos = new Vector3(
                actionContent.transform.position.x, 
                actionContent.transform.position.y + (i * -30), 
                actionContent.transform.position.z);
            GameObject tempButtonObj = Instantiate(buttonPrefab, pos, Quaternion.identity, actionContent.transform);
            Button tempButton = tempButtonObj.GetComponent<Button>();
            actionButtonList.Add(tempButton);
            ConfigCombatButton temp = tempButtonObj.GetComponent<ConfigCombatButton>();
            tempButtonObj.name = action.GetName() + " Button";

            temp.setData(action.GetName(), "", action);
            tempButton.onClick.AddListener(delegate { combatSystem.SetCombatAction(action); });

            if (i > 0)
            {
                Navigation nav = actionButtonList[i - 1].navigation;
                nav.selectOnDown = tempButton;
                actionButtonList[i - 1].navigation = nav;

                nav = tempButton.navigation;
                nav.selectOnUp = actionButtonList[i - 1];
                tempButton.navigation = nav;
            }

            i++;
        }
    }

    private void clearLeftPage()
    {
        magicPageImage.SetActive(false);
        itemPageImage.SetActive(false);
        actionPageImage.SetActive(false);
    }

    public void showCombatBook()
    {

    }

    public void hideCombatBook()
    {

    }

    public void showMagicPage()
    {
        clearLeftPage();
        magicPageImage.SetActive(true);
        pageTitleText.text = "Attack";
    }

    public void showItemPage()
    {
        clearLeftPage();
        itemPageImage.SetActive(true);
        pageTitleText.text = "Items";
    }

    public void showActionPage()
    {
        clearLeftPage();
        actionPageImage.SetActive(true);
        pageTitleText.text = "Actions";
    }

    public void confirmAttackPage()
    {
        //Generate attack buttons and move focus to right page

        attackContent.SetActive(true);
        itemContent.SetActive(false);
        actionContent.SetActive(false);

        attackButtonList[0].Select();
    }

    public void confirmItemPage()
    {
        //Generate item buttons and move focus to right page
    }

    public void confirmActionPage()
    {
        //Generate action buttons and move focus to right page

        attackContent.SetActive(false);
        itemContent.SetActive(false);
        actionContent.SetActive(true);

        actionButtonList[0].Select();
    }
}

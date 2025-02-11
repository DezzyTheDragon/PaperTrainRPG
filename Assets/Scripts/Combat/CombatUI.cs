using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CombatUI : MonoBehaviour
{
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

    private void Start()
    {
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
            GameObject tempButton = Instantiate(buttonPrefab, pos, Quaternion.identity, attackContent.transform);
            ConfigCombatButton temp = tempButton.GetComponent<ConfigCombatButton>();
            temp.setData(attack.GetName(), "");

            i++;
        }

        scrollRectTransform.sizeDelta = new Vector2(0, 30 * i);
    }

    private void initItemPage()
    {

    }

    private void initActionPage()
    {

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
    }

    public void confirmItemPage()
    {
        //Generate item buttons and move focus to right page
    }

    public void confirmActionPage()
    {
        //Generate action buttons and move focus to right page
    }
}

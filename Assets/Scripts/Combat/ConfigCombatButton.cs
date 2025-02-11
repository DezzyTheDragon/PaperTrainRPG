using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigCombatButton : MonoBehaviour
{
    private string actionName;
    private TMP_Text text;
    private Texture2D image;
    [SerializeField] private GameObject icon;
    [SerializeField] private GameObject buttonText;

    private void Start()
    {
        
    }

    public void setData(string name, string resource)
    {
        actionName = name;
        text = buttonText.GetComponent<TMP_Text>();
        text.text = name;
        Debug.LogError("Texture loading not implemented");
        //image = icon.GetComponent<>();
    }
}

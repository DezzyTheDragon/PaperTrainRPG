using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button defaultButton;

    private void Start()
    {
        defaultButton.Select();
    }

    public void OnStorySelect()
    {

    }

    public void OnWellSelect()
    {

    }

    public void OnOptionSelect()
    {

    }

    public void OnQuitSelect()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "LangObj", menuName = "Language", order = 1)]
public class LanguageObj : ScriptableObject
{
    public string region;
    public string fileName;

    private Dictionary<string, string> langDict = new Dictionary<string, string>();

    public string GetLangString(string key)
    {
        return langDict[key];
    }

    public void ChangeRegion(string r)
    {
        region = r;
        readFile();
    }

    public void readFile()
    {
        string targetFile = "LanguageFiles/" + region + "/" + fileName; 
        TextAsset file = Resources.Load<TextAsset>(targetFile);

    }
}

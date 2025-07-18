using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum dialougeType { NORMAL, TEXT_CHOICE, ITEM_CHOICE, INVALID }

public struct speakerCharacter {
    public string name;
    public string icon;         //The pfp used for the dialouge box
    public string font;
    public string dialougeBox;  //The visual style of the dialouge box
    public string speakingSound;
}

public struct dialouge {
    public speakerCharacter character;
    public dialougeType type;
    public string[] text;
}

/*TODO: Dialoug situations to account for
 *  - Normal talk, with multiple pages of text
 *  - Player choice, player is given options between selections and things happen accordingly
 *  - Item choice, players options are based on items. This is for stores or places to put key items
 */

public class DialougeSystem : MonoBehaviour, IUINav
{
    private struct dialougeParse
    {
        public string character;
        public string type;
        public string[] text;
        public string source;
    }

    private string regon = "English";
    private dialouge activeDialouge;

    public void ParseDialouge(string file, string key)
    {
        string fileLocation = string.Concat("LanguageFiles/", regon, "/", file);
        TextAsset textAsset = Resources.Load<TextAsset>(fileLocation);

        if (textAsset == null)
        {
            Debug.LogError("Faild to find requested file at " + fileLocation);
            return;
        }

        
    }

    public void OnBack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNavigation(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}

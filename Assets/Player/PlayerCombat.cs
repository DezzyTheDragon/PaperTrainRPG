using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour, ICombat
{
    PlayerStats stats = PlayerStats.GetInstatnce();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoTurn()
    {
        throw new System.NotImplementedException();
    }

    public string GetName()
    {
        throw new System.NotImplementedException();
    }

    public void Highlight()
    {
        throw new System.NotImplementedException();
    }

    public void Unhighlight()
    {
        throw new System.NotImplementedException();
    }

    
}

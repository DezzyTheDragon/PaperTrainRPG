using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingZone : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private int zoneID = -1;
    [SerializeField] private int targetZoneID = 0;

    private bool ignorePlayer = false;

    private ScreenManager manager;

    void Start()
    {
        manager = GameObject.FindWithTag("GameManager").GetComponent<ScreenManager>();
    }

    void Update()
    {
        
    }

    public int GetZoneID()
    {
        return zoneID;
    }

    public void EnablePlayerIgnore()
    {
        ignorePlayer = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (manager == null)
        {
            Debug.LogError("No game manager found! Abort transition!");
            return;
        }
        if (other.gameObject.tag == "Player" && !ignorePlayer)
        {
            Debug.Log("PLAYER DETECTED!");
            manager.targetLoadingZoneID = targetZoneID;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ignorePlayer = false;
        }
    }
}

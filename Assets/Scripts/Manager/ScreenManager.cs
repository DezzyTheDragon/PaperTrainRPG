using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    private GameObject player;
    public int targetLoadingZoneID;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        
    }

    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(mode != LoadSceneMode.Additive)
        {
            Debug.Log("Searching for player in loaded scene");
            player = GameObject.FindWithTag("Player");
            if (player == null)
            {
                Debug.LogError("Player was not found in scene!");
                return;
            }
            GameObject[] zones = GameObject.FindGameObjectsWithTag("LoadingZone");
            
            foreach (GameObject zone in zones)
            {
                LoadingZone zoneInfo = zone.GetComponent<LoadingZone>();
                if(zoneInfo.GetZoneID() == targetLoadingZoneID)
                {
                    zoneInfo.EnablePlayerIgnore();
                    player.GetComponent<PlayerWorld>().WarpPosition(zoneInfo.gameObject.transform.position);

                    break;
                }
            }
        }
    }
}

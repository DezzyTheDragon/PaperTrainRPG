using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerObjectRef;
    [Header("Lock pan to axis")]
    public bool panX = true;
    public bool panY = false;
    public bool panZ = false;

    [Header("Axis Offset")]
    public float offsetX = 0;
    public float offsetY = 0;
    public float offsetZ = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObjectRef == null)
        {
            Debug.LogError("Camera has no player reference!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObjectRef != null)
        {
            Vector3 playerPos = playerObjectRef.transform.position;

            Vector3 newPos = new Vector3(
                panX ? playerPos.x + offsetX : gameObject.transform.position.x,
                panY ? playerPos.y + offsetY : gameObject.transform.position.y,
                panZ ? playerPos.z + offsetZ : gameObject.transform.position.z);

            //gameObject.transform.position = newPos * Time.deltaTime;
            gameObject.transform.position = newPos;
        }
    }
}

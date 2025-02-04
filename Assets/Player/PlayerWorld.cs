using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWorld : MonoBehaviour
{
    //MOVEMENT ========================================
    private float speed = 2.5f;
    private bool canMove = true;
    private float jumpHeight = 0.5f;
    private float gravity = -9.81f;

    private Vector3 movement;
    private Vector3 velocity;
    private CharacterController characterController;
    //INTERACT ========================================
    [SerializeField]
    private GameObject indicator;
    Interactable interactable;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        indicator.SetActive(false);
    }

    void Update()
    {
        MovePlayer();
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * 0.025f);
    }

    private bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 0.025f))
        {
            return true;
        }

        return false;
    }

    private void MovePlayer() 
    {
        if (canMove)
        {
            //if(characterController.isGrounded && velocity.y < 0)
            if(isGrounded() && velocity.y < 0)
            {
                velocity.y = 0;
            }

            characterController.Move(movement * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        Vector2 temp = context.ReadValue<Vector2>();
        movement = new Vector3(temp.x, 0.0f, temp.y);
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (isGrounded() && context.phase == InputActionPhase.Started)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
        //TODO: Implement hold to jump higher
        //Debug.Log(context.duration);
    }

    public void OnInteract(InputAction.CallbackContext context) 
    {
        if (interactable != null) 
        {
            interactable.Interact();
        }
    }

    public void OnAction(InputAction.CallbackContext context) { }

    public void OnMenu(InputAction.CallbackContext context) { }

    public void WarpPosition(Vector3 pos) 
    {    
        Debug.Log("CC is not null");
        characterController.enabled = false;
        transform.position = pos;
        characterController.enabled = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        Interactable temp = other.GetComponent<Interactable>();
        if(temp != null)
        {
            indicator.SetActive(true);
            interactable = temp;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        Interactable temp = other.GetComponent<Interactable>();
        if(temp != null)
        {
            indicator.SetActive(false);
            interactable = null;
        }
    }

    
}

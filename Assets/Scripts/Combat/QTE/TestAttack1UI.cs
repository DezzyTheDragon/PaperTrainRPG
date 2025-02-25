using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TestAttack1UI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Sprite buttonSprite1;
    [SerializeField] private Sprite buttonSprite2;
    [SerializeField] private Sprite buttonSprite3;

    private Animator animator;

    private PlayerControls playerControls;
    private bool inRange = false;
    private bool didPress = false;
    private bool success = true;

    private PlayerCombat playerRef;

    public void SetPlayerRef(PlayerCombat player)
    {
        playerRef = player;
    }

    public void SetSliderValue(float value)
    {
        slider.value = value;
    }

    public void SetInRange()
    {
        inRange = true;
        didPress = false;
    }

    public void SetOutRange()
    {
        inRange = false;
        if (!didPress)
        {
            Debug.Log("Pressed Too Late!");
            OnFailQTE();
        }
    }

    public void EndOfAnim()
    {
        SetOutRange();
        QTE_End();
    }

    private void ButtonPressed(InputAction.CallbackContext context)
    {
        if (inRange)
        {
            didPress = true;
            //Give pressed feedback
            Debug.Log("YES!");
        }
        else
        {
            Debug.Log("Pressed Too Soon!");
            OnFailQTE();
        }
    }

    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        playerControls = new PlayerControls();
        playerControls.Combat.Enable();

        playerControls.Combat.Button1.performed += ButtonPressed;
    }

    private void OnDisable()
    {
        playerControls.Combat.Disable();
    }

    private void OnFailQTE()
    {
        //Pause the animation and end
        Debug.Log("FAILED");
        success = false;
        
        animator.speed = 0;

        QTE_End();
    }

    private void QTE_End()
    {
        playerRef.QTEFinished(success);

        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IUINav
{
    public void OnNavigation(InputAction.CallbackContext context);
    public void OnConfirm(InputAction.CallbackContext context);
    public void OnBack(InputAction.CallbackContext context);
}

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
  private ActionBasedController controller;

  void Awake()
  {
    controller = GetComponent<ActionBasedController>();

    controller.activateAction.action.started += OnTriggerPress;
    controller.activateAction.action.canceled += OnTriggerRelease;
  }

  void OnTriggerPress(InputAction.CallbackContext context)
  {
        
  }

  void OnTriggerRelease(InputAction.CallbackContext context)
  {
    
  }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControllerScript : MonoBehaviour
{

    [SerializeField] InputActionReference gripInputAction;
    [SerializeField] InputActionReference triggerInputAction;

    Animator handAnimator;

    private void Awake()
    {
        handAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {

        gripInputAction.action.performed += GripPressed;
        triggerInputAction.action.performed += TriggerPressed;

    }

    private void TriggerPressed(InputAction.CallbackContext trigger)
    {
        handAnimator.SetFloat("Trigger", trigger.ReadValue<float>());
    }

    private void GripPressed(InputAction.CallbackContext grip)
    {
        handAnimator.SetFloat("Grip", grip.ReadValue<float>());
    }

    private void OnDisable()
    {
        gripInputAction.action.performed -= GripPressed;
        triggerInputAction.action.performed -= TriggerPressed;
    }

}

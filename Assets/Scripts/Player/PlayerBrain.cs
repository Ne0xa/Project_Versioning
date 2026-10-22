using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] InputActionReference myAction;
    [SerializeField] Movement _movement;
    
    private void Start()
    {
        myAction.action.started += OnMoveUpdate;
        myAction.action.performed += OnMoveUpdate;
        myAction.action.canceled += OnMoveStop;
    }

    void OnDestroy()
    {
        myAction.action.started -= OnMoveUpdate;
        myAction.action.performed -= OnMoveUpdate;
        myAction.action.canceled -= OnMoveStop;
    }

    void OnMoveUpdate(InputAction.CallbackContext ctx)
    {
        
    }
    
    void OnMoveStop(InputAction.CallbackContext ctx)
    {
        
    }
}

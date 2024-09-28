using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public event Action<Vector2> OnMove; 
    public event Action<bool> OnAction; 
    
    private Inputs _inputs;  
    
    private Vector2 _moveInput;  
    private bool _actionInput;  

    private void OnEnable()
    {
        SetupInput();
        EnableInput();
    }
    private void OnDisable()
    {
        DisableInput();
    }
    private void SetupInput()
    {
        _inputs = new Inputs(); 
        
        _inputs.Player.Movement.performed += OnMovement;
        _inputs.Player.Movement.canceled += OnMovement;
        
        _inputs.Player.Action.performed += OnActionDone;
        _inputs.Player.Action.canceled += OnActionDone;
    }
    
    private void EnableInput()
    {
        _inputs.Player.Enable(); 
    }
    private void DisableInput()
    {
        _inputs.Player.Disable(); 
    }
    private void OnMovement(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>(); 
        OnMove?.Invoke(_moveInput);  
    }

    private void OnActionDone(InputAction.CallbackContext context)
    {
        _actionInput = context.ReadValueAsButton();
        OnAction?.Invoke(_actionInput);
    }
//NOTE: this is to move the player continuously
    private void Update()
    {
       if (OnMove != null && _moveInput != Vector2.zero)
       {
            OnMove(_moveInput);  
       }
    }
}

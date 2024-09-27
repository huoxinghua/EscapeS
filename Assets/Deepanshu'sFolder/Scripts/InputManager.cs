using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public event Action<Vector2> onMove; 
    
    private Inputs _inputs; 
    private Vector2 moveInput; 
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
        _inputs.Player.Movement.performed += OnMove;
        _inputs.Player.Movement.canceled += OnMove; 
    }

    private void EnableInput()
    {
        _inputs.Player.Enable(); 
    }
    private void DisableInput()
    {
        _inputs.Player.Disable(); 
    }
    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>(); 
        onMove?.Invoke(moveInput); 
    }
    private void Update()
    {
        if (onMove!= null && moveInput != Vector2.zero)
        {
            onMove(moveInput);
        }
    }
}

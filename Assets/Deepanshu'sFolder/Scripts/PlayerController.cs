using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager; 
    [SerializeField] private Transform playerTransform; 
    [SerializeField] private Rigidbody2D playerRigidbody; 
    
    private Vector2 _movementDirection; 
    [SerializeField] private float moveDistance = 1f; 
    private void OnEnable()
    {
        inputManager.onMove += OnMove;
    }
    private void OnDisable()
    {
        inputManager.onMove -= OnMove;
    }
    private void OnMove(Vector2 inputValue)
    {
        _movementDirection = new Vector2(inputValue.x, inputValue.y).normalized;
        MovePlayer(_movementDirection);
    }
    private void MovePlayer(Vector2 direction)
    {
        Vector2 newPosition = playerTransform.position + (Vector3)(direction * moveDistance);
        playerRigidbody.MovePosition(newPosition);
    }
}

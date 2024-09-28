using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject prefabToSpawn; 
    [SerializeField] private float moveDistance = 0.1f; 
    
    private readonly bool _isMoving = false;
    
    private Vector2 _movementDirection; 
    private Vector2 _lastSpawnPosition; 
    private void OnEnable()
    {
        inputManager.OnMove += OnMovement;
        inputManager.OnAction += OnActionDone;
    }
    private void OnDisable()
    {
        inputManager.OnMove -= OnMovement;
        inputManager.OnAction -= OnActionDone;
    }
    private void OnMovement(Vector2 inputValue)
    {
        if (!_isMoving) 
        {
            _movementDirection = new Vector2(inputValue.x, inputValue.y).normalized;
            MovePlayer(_movementDirection);
        }
    }
    private void OnActionDone(bool inputValue)
    {
        if (inputValue)
        {
            Vector2 currentPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
            // this will make sure that the smell bomb won't spawn in the same location
            
            if (currentPosition != _lastSpawnPosition) 
            {
                Instantiate(prefabToSpawn, playerTransform.position, Quaternion.identity);
                _lastSpawnPosition = currentPosition; 
            }
        }
    }
    private void MovePlayer(Vector2 direction)
    {
        Vector2 newPosition = playerTransform.position + (Vector3)(direction * moveDistance);
        playerRigidbody.MovePosition(newPosition);
    }
}

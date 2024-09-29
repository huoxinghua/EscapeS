using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float moveDistance = 0.1f;
    [SerializeField] private float spawnCooldownDuration = 5f;
    
    private readonly bool _isMoving = false;
    private bool _canSpawn = true;
    
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
        if (inputValue && _canSpawn)
        {
            Vector2 currentPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);

            
            if (currentPosition != _lastSpawnPosition)
            {
                Instantiate(prefabToSpawn, playerTransform.position, Quaternion.identity);
                _lastSpawnPosition = currentPosition;

                StartCoroutine(SpawnCooldown());  
            }
        }
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector2 newPosition = playerTransform.position + (Vector3)(direction * moveDistance);
        playerRigidbody.MovePosition(newPosition);
    }
    private IEnumerator SpawnCooldown()
    {
        _canSpawn = false;  
        yield return new WaitForSeconds(5f);  // just for delay
        _canSpawn = true;  
    }
    
}

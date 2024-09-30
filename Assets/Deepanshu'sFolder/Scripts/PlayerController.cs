using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRigidbody;
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private float moveDistance = 1f;

    private bool isMoving = false;

    private Vector2 _movementDirection;
    private Vector2 lastSpawnPosition;
    private void OnEnable()
    {
        inputManager.onMove += OnMove;
        inputManager.onAction += OnAction;
    }
    private void OnDisable()
    {
        inputManager.onMove -= OnMove;
        inputManager.onAction -= OnAction;
    }
    private void OnMove(Vector2 inputValue)
    {
        if (!isMoving)
        {
            _movementDirection = new Vector2(inputValue.x, inputValue.y).normalized;
            MovePlayer(_movementDirection);
        }
    }
    private void OnAction(bool inputValue)
    {
        if (inputValue)
        {
            Vector2 currentPosition = new Vector2(playerTransform.position.x, playerTransform.position.y);
            // this will make sure that the smell bomb wont spawn in the same loaction

            if (currentPosition != lastSpawnPosition)
            {
                Instantiate(prefabToSpawn, playerTransform.position, Quaternion.identity);
                lastSpawnPosition = currentPosition;
            }
        }
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector2 newPosition = playerTransform.position + (Vector3)(direction * moveDistance);
        playerRigidbody.MovePosition(newPosition);
    }

    public SoundEffectsManager soundEffectsManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift)) // Replace with your bomb drop condition
        {
            DropBomb();
        }
    }

    void DropBomb()
    {
        // Your bomb drop logic here

        // Play the boing sound
        if (soundEffectsManager != null)
        {
            soundEffectsManager.PlayBoingSound();
        }
    }

    public class GameManager : MonoBehaviour
    {
        public LevelCompleteManager levelCompleteManager;

        public void CompleteLevel()
        {
            // Your level completion logic here (e.g., loading the next level, showing UI, etc.)

            // Play the level complete music
            if (levelCompleteManager != null)
            {
                levelCompleteManager.PlayLevelCompleteMusic();
            }
        }
    }


    public PointCollectionManager pointCollectionManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PointItem")) // Replace with your point item tag
        {
            // Collect the point (e.g., increase score)
            CollectPoint();

            // Play the point collection sound
            if (pointCollectionManager != null)
            {
                pointCollectionManager.PlayPointCollectionSound();
            }

            // Destroy the point item
            Destroy(other.gameObject);
        }
    }

    void CollectPoint()
    {
        // Your point collection logic here (e.g., increase score)
    }
}

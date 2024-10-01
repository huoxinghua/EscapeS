using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public Transform spawnpoint;
    [SerializeField] public int maxHealth = 3;
    public int health; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            health -= 1;
            Debug.Log(health);
            
            if (health <= 0)
            {
                Die();
            }
            Respawn();
        }
    }
    private void Awake()
    {
        health = maxHealth;
    }
    private void Respawn()
    {
        transform.position = spawnpoint.position;
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager._points = 0;
    }
}



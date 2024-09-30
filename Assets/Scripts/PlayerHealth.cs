using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public Transform _spawnpoint;
    [SerializeField] public int _maxHealth = 3;
    public int Health; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            Health -= 1;
            Debug.Log(Health);
            
            if (Health <= 0)
            {
                Die();
            }
            Respawn();
        }
    }
    private void Awake()
    {
        Health = _maxHealth;
    }
    private void Respawn()
    {
        transform.position = _spawnpoint.position;
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager._points = 0;
    }
}



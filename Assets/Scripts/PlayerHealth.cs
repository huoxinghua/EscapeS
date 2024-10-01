using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public Transform spawnpoint;
    [SerializeField] public int maxHealth = 3;
    public int health;
    [SerializeField] private CinemachineVirtualCamera cinemachineCam;
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
            //Respawn();
        }
    }

   void TakeDamage(int amount)
    {
        health = maxHealth;
    }


    public void Heal (int amount)
    {
        transform.position = spawnpoint.position;
        cinemachineCam.Priority = 20;
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManager.Points = 0;
        cinemachineCam.Priority = 20;
    }
}

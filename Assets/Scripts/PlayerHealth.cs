using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public List<Transform> healthPoints; 
    [SerializeField] public Transform spawnpoint; 
    [SerializeField] public int maxHealth = 3; 
    public int health; 
    [SerializeField] private CinemachineVirtualCamera cinemachineCam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void Awake()
    {
        health = maxHealth;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            health -= 1; 
            if (healthPoints.Count > 0)
            {
                var lastHealthPoint = healthPoints[healthPoints.Count - 1];
                lastHealthPoint.gameObject.SetActive(false); 
                healthPoints.RemoveAt(healthPoints.Count - 1); 
            }
            if (health <= 0)
            {
                Die();
            }
            else
            {
                Respawn();
            }
        }

        if (other.CompareTag("END"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
            GameManager.Points = 0; 
            health = maxHealth; 
            healthPoints.ForEach(hp => hp.gameObject.SetActive(true)); 
            cinemachineCam.Priority = 20; 
            SceneManager.LoadScene(0);
        }
    }
    private void Respawn()
    {
        
        transform.position = spawnpoint.position;
        cinemachineCam.Priority = 20; 
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        GameManager.Points = 0; 
        health = maxHealth; 
        healthPoints.ForEach(hp => hp.gameObject.SetActive(true)); 
        cinemachineCam.Priority = 20; 
    }
}

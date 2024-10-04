using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System.Collections.Generic;
public class PlayerHealth : MonoBehaviour
{
     [SerializeField] public List<Transform> healthPoints;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] public int maxHealth = 3;
    public int health;
    [SerializeField] private CinemachineVirtualCamera cinemachineCam;
    [SerializeField] private GameObject _player;
    private AudioSource audioSource;
    public AudioClip soundEffect;

    void Start()
    {
        cinemachineCam.Priority = 20;
        audioSource = GetComponent<AudioSource>();
    }

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
        transform.position = spawnPoint.position;
        cinemachineCam.Priority = 20;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("END"))
        {
            cinemachineCam.Priority = 20;
        }

        if (other.CompareTag("Enemy"))
        {
            // Reduce health by 1
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
    }

   
    private void Respawn()
    {
        transform.position = spawnPoint.position;
        cinemachineCam.Priority = 20;
        PlaySound(); 
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        PlaySound(); 
    }
    public void PlaySound()
    {
        
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            Debug.LogError("Sound effect or AudioSource is not assigned.");
        }
    }
}

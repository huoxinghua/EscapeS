using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBoingSound()
    {
        audioSource.Play();
    }


    public SoundEffectsManager soundEffectsManager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) // Replace with your bomb drop condition
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
}
using UnityEngine;

public class LevelCompleteManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayLevelCompleteMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
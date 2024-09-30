using UnityEngine;

public class LevelFailManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFailManager()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
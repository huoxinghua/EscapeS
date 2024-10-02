using UnityEngine;

public class PointCollectionManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPointCollectionSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
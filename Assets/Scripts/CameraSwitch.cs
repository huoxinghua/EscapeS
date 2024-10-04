using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] public Transform transisionspawnpoint;
    public CinemachineVirtualCamera mainCameraVcam;
    public CinemachineVirtualCamera secondaryCameraVcam;
    [SerializeField] GameObject _player;
    private AudioSource audioSource;
    public AudioClip soundEffect;
    private void Start()
    {
        mainCameraVcam.Priority = 10; 
        secondaryCameraVcam.Priority = 5; 
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchToSecondaryCamera();
            TransisionSwitch();
            PlaySound();
        }
        
    }
    
    void SwitchToSecondaryCamera()
    {
        secondaryCameraVcam.Priority = 10;
        mainCameraVcam.Priority = 5; 
    }

    private void TransisionSwitch()
    {
       _player.transform.position =transisionspawnpoint.position;
      
    }
    public void PlaySound()
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
    
}

using UnityEngine;
using Cinemachine;
public class CameraSwitch : MonoBehaviour
{
    [SerializeField] public Transform transisionspawnpoint;
    public CinemachineVirtualCamera mainCameraVcam;
    public CinemachineVirtualCamera secondaryCameraVcam;
    [SerializeField] GameObject _player;
    private void Start()
    {
        mainCameraVcam.Priority = 10; 
        secondaryCameraVcam.Priority = 5;  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SwitchToSecondaryCamera();
            TransisionSwitch();
        }
    }
    void SwitchToSecondaryCamera()
    {
        secondaryCameraVcam.Priority = 15;
        mainCameraVcam.Priority = 5; 
    }

    private void TransisionSwitch()
    {
       _player.transform.position =transisionspawnpoint.position; 
    }
}

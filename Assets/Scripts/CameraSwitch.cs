using UnityEngine;
using Cinemachine;
public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera mainCameraVcam;
    public CinemachineVirtualCamera secondaryCameraVcam;
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
        }
    }
    void SwitchToSecondaryCamera()
    {
        secondaryCameraVcam.Priority = 15;
        mainCameraVcam.Priority = 5; 
    }
}

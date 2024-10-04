using UnityEngine;
public class Collectables : MonoBehaviour
{
    
   [SerializeField] public TMPro.TMP_Text collectText;
   private AudioSource audioSource;
   public AudioClip soundEffect;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            GameManager. Points += 1;
            collectText.text = GameManager.Points.ToString();
            Destroy(gameObject);
            PlaySound();
        }
        PlaySound();
    }
    public void PlaySound()
    {
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}

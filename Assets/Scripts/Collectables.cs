using UnityEngine;
public class Collectables : MonoBehaviour
{
   [SerializeField] public TMPro.TMP_Text collectText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        { 
            GameManager. Points += 1;
            collectText.text = GameManager.Points.ToString();
            Destroy(gameObject);
        }
    }
}
